using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var NameUserView = FindViewById<TextView>(Resource.Id.ResultUserName);
            var StatusView = FindViewById<TextView>(Resource.Id.ResultStatus);
            var CodeView = FindViewById<TextView>(Resource.Id.ResultCode);
            var ServiceClient = new SALLab08.ServiceClient();
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var Result = await ServiceClient.ValidateAsync("usuario@email.com", "PassWrod", myDevice);
            NameUserView.Text = Result.Fullname.ToString();
            StatusView.Text = Result.Status.ToString();
            CodeView.Text = Result.Token.ToString();
        }
    }
}


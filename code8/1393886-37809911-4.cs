    [Activity(Label = "testapp", MainLauncher = true, Theme = "@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]
        public class SplashActivity : Activity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
               // SetContentView(Resource.Layout.LaunchScreen); //Set a splash screen here if you wish
                Java.Lang.Runnable runnable = new Java.Lang.Runnable(() =>
                {
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                });
    
                new Handler().PostDelayed(runnable, 1000);
            }
        }

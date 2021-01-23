    [Activity(Label = "testapp", MainLauncher = true, Theme = "@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.LaunchScreen);
                Java.Lang.Runnable runnable = new Java.Lang.Runnable(() =>
                {
                    Intent i = new Intent(this, typeof(AnotherActivity));
                    StartActivity(i);
                });
    
                new Handler().PostDelayed(runnable, 1000);
            }
        }

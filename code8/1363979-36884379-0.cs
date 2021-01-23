    [Activity(Label = "MainActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity: Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            var intent = new Intent(this, typeof(SecondActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            //Navigation to SecondActivity
            StartActivity(intent);
            //delete main activity from navigation
            Finish();
        }
    }

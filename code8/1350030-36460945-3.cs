    [Activity(Label = "App3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            SetContentView(Resource.Layout.Main);
    
            var button = FindViewById<Button>(Resource.Id.MyButton);
    
            button.Click += delegate
            {
                var alarmIntent = new Intent(this, typeof(AlarmReceiver));
                alarmIntent.PutExtra("title", "Hello");
                alarmIntent.PutExtra("message", "World!");
    
                var pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
    
                var alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
                alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 5*1000, pending);
            };
        }
    }

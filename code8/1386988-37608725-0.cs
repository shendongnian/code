    // ** MainActivity
    namespace GetLocation.Droid
    {
        [Activity(Label = "GetLocation.Droid", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity
        {
            //I initialize my view(s) here to access them from outside of OnCreate().
            Button button;
            //I found this in an Android BroadcastReceiver example of how to access the MainActivity from the BroadcastReceiver.
            private static MainActivity ins;
            public static MainActivity getInstace()
            {
                return ins;
            }
            protected override void OnCreate(Bundle bundle)
            {
            
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Main);
                button = FindViewById<Button>(Resource.Id.myButton);
                ins = this;
                button.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(MyIntentService));
                    StartService(intent);
                };
                LocationBroadcastReciever lbr = new LocationBroadcastReciever();
                LocalBroadcastManager.GetInstance(this).RegisterReceiver(lbr, new IntentFilter("test"));
            }
            public void SetButtonText(string text)
            {
                button.Text = text;
            }
        }
        [BroadcastReceiver]
        [IntentFilter(new[] { "test" })]
        public class LocationBroadcastReciever : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                string text = intent.GetStringExtra("title");
                MainActivity.getInstace().SetButtonText(text);
            }
        }
    }

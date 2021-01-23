    [Service]
    public class BackgroundService : Service {
        private static LocationReceiver mTickReceiver;
    
        public BackgroundService()
        {
    
        }
    
    
    
        
        public override IBinder OnBind(Intent arg0)
        {
            return null;
        }
    
       
     public override StartCommandResult OnStartCommand (Android.Content.Intent intent, StartCommandFlags flags, int startId)
     {
         
    
            return StartCommandResult.Sticky;
      }
    
        
        public override Void OnCreate()
        {
            registerReceiver();
        }
    
       
        public override Void OnDestroy()
        {
            UnregisterReceiver(mTickReceiver);
            mTickReceiver = null;
        }
    
    
    
        private void registerReceiver()
        {
            
           mTickReceiver= new LocationReceiver();
    
            IntentFilter filter = new IntentFilter(Android.Content.Intent.ActionTimeTick); // this will broadcast Intent every minute
            RegisterReceiver(mTickReceiver, filter);
        }
    
        // you can write this class in separate cs file
        
        
        [BroadcastReceiver(Enabled = true)]
        
        [IntentFilter(new[] { Android.Content.Intent.ActionTimeTick })]
        
        public class LocationReceiver : BroadcastReceiver
        {
        
            public override Void OnReceive(Context context, Intent intent)
            {
        
                // sample data, you should get your location here,
                // one way is to implement location logic in this class
                       double SampleLatitude=52.01566;
                        double SampleLongitude=65.00487;
        
                        // assuming above coordinates are from some location manager code
                        Intent i=new Intent();
                        i.SetAction("LocationData");
                        i.PutExtra("Latitude",SampleLatitude);
                        i.PutExtra("Longitude",SampleLongitude);
                        // PREPARE BROADCAST FOR MAINACTIVITY
                        SendBroadcast(i);  // this broadcast will be received by mainactivity
            }
        }
        
        }

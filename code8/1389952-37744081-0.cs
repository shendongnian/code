    [BroadcastReceiver]
    class MyBroadcastReceiver : BroadcastReceiver
    {
        public interface LocationDataInterface
        {
            void OnLocationChanged(LatLng point);
        }
        public static readonly string GRID_STARTED = "GRID_STARTED";
        private LocationDataInterface mInterface;
        
        private LatLng a;
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == GRID_STARTED)
            {
                try
                {
                    // data you got from background service
                    a = new LatLng(intent.GetDoubleExtra("latitude",0), intent.GetDoubleExtra("longitude",0));
                    mInterface = (LocationDataInterface)context;
                    mInterface.OnLocationChanged(a);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(context, ex.Message, ToastLength.Short).Show();
                }
            }
        }
    }

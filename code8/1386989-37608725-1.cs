    namespace GetLocation.Droid
    {
        [Service]
        [IntentFilter(new String[] { "com.mytos.MyIntentService" })]
        public class MyIntentService : IntentService
        {
            protected override void OnHandleIntent(Intent intent)
            {
                SendBroadcast("My message");
            }
            private void SendBroadcast(string message)
            {
                //Here you can of course send whatever variable you want. Mine is a string
                Intent intent = new Intent("test");
                intent.PutExtra("title", message);
                LocalBroadcastManager.GetInstance(this).SendBroadcast(intent);
            }
        }
    }

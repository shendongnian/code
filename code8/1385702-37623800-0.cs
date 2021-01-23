    [Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
    class MyGcmListenerService : GcmListenerService
    {
        public override void OnMessageReceived(string from, Bundle data)
        {
            string msg = data.GetString("message");
            // send a string via Xamarin MessagingCenter
            MessagingCenter.Send<object, string>(this, "ShowAlert", msg);
        }
    }

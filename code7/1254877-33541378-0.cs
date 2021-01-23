        public class PushNotificationHandler : IDisposable
    {
        private static readonly string googleApiKey;
        private static PushBroker pushBrokerInstance;
        static PushNotificationHandler()
        {
            googleApiKey = ConfigurationManager.AppSettings["GoogleAPIKey"].ToString();
            pushBrokerInstance = new PushBroker();
            pushBrokerInstance.RegisterGcmService(new GcmPushChannelSettings(googleApiKey));
        }
        public static void SendGCMNotification(Notification messageObj, String CloudMessagingId)
        {
            String Content = Newtonsoft.Json.JsonConvert.SerializeObject(messageObj);
            pushBrokerInstance.QueueNotification(new GcmNotification().ForDeviceRegistrationId(CloudMessagingId).WithJson(Content));
        }
    }

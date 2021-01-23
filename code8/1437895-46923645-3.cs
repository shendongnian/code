    public class SmsSender : ISmsSender
    {
        private readonly IAmazonSimpleNotificationService _sns;
    
        public SmsSender(ISNSFactory snsFactory)
        {
            _sns = snsFactory.ForSMS();
        }
    
        .......
     }
    public class DeviceController : Controller
    {
        private readonly IAmazonSimpleNotificationService _sns;
        public DeviceController(ISNSFactory snsFactory)
        {
            _sns = snsFactory.ForDefault();
        }
         .........
    }

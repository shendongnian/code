    using SmsTest.SmsService;
    
    namespace SmsTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var msg = "Your SMS Message";
                var serviceProviderId = 42;
                
                // Use the constructor overloads for GuideMeServiceClient to configure how to connect
                var service = new GuideMeServiceClient();
                service.smsSend(serviceProviderId, msg);
            }
        }
    }

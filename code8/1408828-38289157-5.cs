    using SmsTest.SmsService;
    
    namespace SmsTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var msg = "Your SMS Message";
                var serviceProviderId = 42;
                
                // Use the constructor overloads for ServiceClient to configure how to connect
                var service = new MyServiceClient();
                service.smsSend(serviceProviderId, msg);
            }
        }
    }

    using System;
    using System.ServiceModel;
    
    namespace Application1
    {
        [ServiceContract]
        public interface IEchoService
        {
            [OperationContract]
            string Echo(string value);
        }
    
        public class EchoService : IEchoService
        {
            public string Echo(string value)
            {
                return string.Format("You send me data'{0}'", value);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost host = new ServiceHost(typeof(EchoService), new Uri[] { new Uri("http://localhost:8000") }))
                {
                    host.AddServiceEndpoint(typeof(IEchoService), new BasicHttpBinding(), "Echo");
                    host.Open();
                    Console.WriteLine("Service is running...");
                    Console.WriteLine("Press Enter to exit if you want to close service.");
                    Console.ReadLine();
                    host.Close();
                }
            }
        }
    }

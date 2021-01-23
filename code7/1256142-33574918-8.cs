    namespace WCFServer
    {
        [ServiceContract]
        public interface IUtils
        {
            [OperationContract]
            void PostPID(int value);
        }
    
        public class Utils : IUtils
        {
            public void PostPID(int value)
            {
                // Do something with value here
                Console.WriteLine(value);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost host = new ServiceHost(
                  typeof(Utils),
                  new Uri[]{
              new Uri("net.pipe://localhost")
            }))
                {
                    host.AddServiceEndpoint(typeof(IUtils),
                      new NetNamedPipeBinding(),
                      "Pipepipe");
    
                    host.Open();
    
                    Console.WriteLine("Service is available. " +
                      "Press <ENTER> to exit.");
                    Console.ReadLine();
    
                    host.Close();
                }
            }
        }
    }

    namespace ConsoleApplication8
    {
        using Microsoft.Practices.Unity;
        using Microsoft.Practices.Unity.Configuration;
    
        public interface IMessagingClient { }
    
        public class ServiceBusMessagingClient : IMessagingClient { }
    
        public class MockMessagingClient : IMessagingClient { }
    
        public class FailoverMessagingClient : IMessagingClient
        {
            private readonly IMessagingClient primaryClient;
            private readonly IMessagingClient secondaryClient;
    
            public FailoverMessagingClient(IMessagingClient primaryClient, IMessagingClient secondaryClient)
            {
                this.primaryClient = primaryClient;
                this.secondaryClient = secondaryClient;
            }
        }
    
        class Program
        {   
            static void Main(string[] args)
            {
                var container = new UnityContainer().LoadConfiguration();
    
                var failOverMessagingClient = container.Resolve<IMessagingClient>("Two");
    
            }
        }
    }

        public class Program
        {
            static void Main(string[] args)
            {
                var container = new UnityContainer();
                container.RegisterType<IDependency, Dependency>();
                container.RegisterType<IHelloWorldService, HelloWorldService>();
                Uri baseAddress = new Uri("http://localhost:8080/hello");
                using (ServiceHost host = new UnityServiceHost(container, typeof(HelloWorldService), baseAddress))
                {
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    host.Description.Behaviors.Add(smb);
    
                    host.Open();
    
                    Console.WriteLine("The service is ready at {0}", baseAddress);
                    Console.WriteLine("Press <Enter> to stop the service.");
                    Console.ReadLine();
                    
                    host.Close();
                }
            }
        }
    
        [ServiceContract]
        public interface IHelloWorldService
        {
            [OperationContract]
            string SayHello(string name);
        }
    
        public interface IDependency
        {
            
        }
    
        public class Dependency : IDependency { }
    
        public class HelloWorldService : IHelloWorldService
        {
            private readonly IDependency _dependency;
    
            public HelloWorldService(IDependency dependency)
            {
                _dependency = dependency;
            }
    
            public string SayHello(string name)
            {
                return string.Format("Hello, {0}", name);
            }
        }

    public class StackOverflow_29825519
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string WhoAmI();
        }
        public class Service : ITest
        {
            string name;
            public Service(string name)
            {
                this.name = name;
            }
            public string WhoAmI()
            {
                return this.name;
            }
        }
        class MyBehavior : IServiceBehavior, IInstanceProvider
        {
            public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
                foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                        ed.DispatchRuntime.InstanceProvider = this;
                    }
                }
            }
            public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
            }
            public object GetInstance(InstanceContext instanceContext, Message message)
            {
                return this.GetInstance(instanceContext);
            }
            public object GetInstance(InstanceContext instanceContext)
            {
                return new Service("John Doe");
            }
            public void ReleaseInstance(InstanceContext instanceContext, object instance)
            {
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            host.Description.Behaviors.Add(new MyBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            ITest proxy = factory.CreateChannel();
            Console.WriteLine("WhoAmI: {0}", proxy.WhoAmI());
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

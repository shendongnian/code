    public class ServiceHosting<T1, T2>
    {
        //Declaration
        protected ServiceHost SelfHost;
        protected string BaseUrlString;
        protected int Port;
        protected string HostUrlString = "";
        protected bool ExtendedBinding;
        //Constructor
        public ServiceHosting(string url, int port, bool extendedBinding = false)
        {
            BaseUrlString = url;
            Port = port;
            ExtendedBinding = extendedBinding;
        }
        //Properties
        protected int Max => int.MaxValue;
        public virtual bool StartService(int port)
        {
            try
            {
                var hostName = System.Net.Dns.GetHostName();
                HostUrlString = $@"net.tcp://{hostName}:{port}{BaseUrlString}"; //GM 10.09.2012: 
                try
                {
                    SelfHost = new ServiceHost(typeof(T1), new Uri(HostUrlString));
                    var smb = SelfHost.Description.Behaviors.Find<ServiceMetadataBehavior>() ??
                              new ServiceMetadataBehavior() { };
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    SelfHost.Description.Behaviors.Add(smb);
                    var throttleBehavior = new ServiceThrottlingBehavior();
                    SelfHost.Description.Behaviors.Add(throttleBehavior);
                    var mexUrlString = String.Format(@"net.tcp://{0}:{1}{2}/mex", hostName, port, BaseUrlString);
                    // Add MEX endpoint
                    SelfHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), new Uri(mexUrlString));
                    // Add binding
                    var binding = ConfigureBinding();
                    // Add application endpoint
                    SelfHost.AddServiceEndpoint(typeof(T2), binding, "");
                    if (ExtendedBinding)
                    {
                        foreach (ServiceEndpoint ep in SelfHost.Description.Endpoints)
                        {
                            foreach (OperationDescription op in ep.Contract.Operations)
                            {
                                var dataContractBehavior = op.Behaviors[typeof(DataContractSerializerOperationBehavior)] as DataContractSerializerOperationBehavior;
                                if (dataContractBehavior != null)
                                {
                                    dataContractBehavior.MaxItemsInObjectGraph = Max;
                                }
                            }
                        }
                    }
                    // Open the service host to accept incoming calls
                    SelfHost.Open();
                }
                catch (CommunicationException)
                {
                    // log
                    SelfHost.Abort();
                    return false;
                }
                catch (Exception)
                {
                    // log
                    SelfHost.Abort();
                    return false;
                }
            }
            catch (Exception)
            {
                // log
                return false;
            }
            return true;
        }
        private NetTcpBinding BaseConfigureBinding()
        {
            return new NetTcpBinding
            { Security = { Mode = SecurityMode.None }, CloseTimeout = new TimeSpan(0, 0, 0, 5) };
        }
        protected virtual NetTcpBinding ConfigureBinding()
        {
            var binding = BaseConfigureBinding();
            if (ExtendedBinding)
            {
                binding.MaxBufferPoolSize = Max;
                binding.MaxReceivedMessageSize = Max;
                binding.MaxBufferSize = Max;
                binding.MaxConnections = 200; //rdoerig 12-03-2013 default value is 10:
                binding.ListenBacklog = 200; //rdoerig 12-03-2013 default value is 10 : buffer of pending connections 
                binding.ReaderQuotas.MaxDepth = Max;
                binding.ReaderQuotas.MaxStringContentLength = Max;
                binding.ReaderQuotas.MaxArrayLength = Max;
                binding.ReaderQuotas.MaxBytesPerRead = Max;
                binding.ReaderQuotas.MaxNameTableCharCount = Max;
                binding.CloseTimeout = new TimeSpan(0, 0, 10, 0);
                binding.OpenTimeout = new TimeSpan(0, 0, 10, 0);
                binding.ReceiveTimeout = new TimeSpan(0, 0, 10, 0);
                binding.SendTimeout = new TimeSpan(0, 0, 10, 0);
            }
            return binding;
        }
        public bool StopService()
        {
            try
            {
                SelfHost?.Close();
            }
            catch (Exception)
            {
                // log
                return false;
            }
            return true;
        }
    }

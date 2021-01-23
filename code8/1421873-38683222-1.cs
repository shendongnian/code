    public static class ServiceConfig
    {
        public static Binding DefaultBinding
        {
            get
            {
                    var binding = new BasicHttpBinding();
                    Configure(binding);
                    return binding;
                } 
            } 
     
            public static void Configure(HttpBindingBase binding)
            {
                if (binding == null)
                {
                    throw new ArgumentException("Argument 'binding' cannot be null. Cannot configure binding.");
                }
     
                binding.SendTimeout = new TimeSpan(0, 0, 30, 0); // 30 minute timeout
                binding.MaxBufferSize = Int32.MaxValue;
                binding.MaxBufferPoolSize = 2147483647;
                binding.MaxReceivedMessageSize = Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
                binding.ReaderQuotas.MaxDepth = Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
            }
     
            public static ServiceMetadataBehavior ServiceMetadataBehavior
            {
                get
                {
                    return new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true, 
                        MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}
                    };
                }
            }
     
            public static ServiceDebugBehavior ServiceDebugBehavior
            {
                get
                {
                    var smb = new ServiceDebugBehavior();
                    Configure(smb);
                    return smb;
                }
            }
     
     
            public static void Configure(ServiceDebugBehavior behavior)
            {
                if (behavior == null)
                {
                    throw new ArgumentException("Argument 'behavior' cannot be null. Cannot configure debug behavior.");
                }
                
                behavior.IncludeExceptionDetailInFaults = true;
            }
    }

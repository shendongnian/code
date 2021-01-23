    public class CustomServiceHost : ServiceHost
    {
        public CustomServiceHost() : base(
            new CustomService(),
            new[] { new Uri(string.Format("net.pipe://localhost/{0}", typeof(ICustomService).FullName)) })
        {
    
        }
    
        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();
    
            foreach (var baseAddress in BaseAddresses)
            {
                AddServiceEndpoint(typeof(ICustomService), new NetNamedPipeBinding(), baseAddress);
            }
        }
    }

    public class NInjectServiceHostFactory : ServiceHostFactory
    {
        private readonly IKernel kernel;
        public NInjectServiceHostFactory()
        {
            kernel = new StandardKernel();
            kernel.Bind<IDummyDependency>().To<DummyDepencency>();
            //add the rest of the mappings here
        }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new NInjectServiceHost(kernel, serviceType, baseAddresses);
        }
    }
    public class NInjectServiceHost : ServiceHost
    {
        public NInjectServiceHost(IKernel kernel, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new NInjectInstanceProvider(kernel));
            }
        }
    }

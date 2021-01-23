    [Module(ModuleName="MyExternalModule", OnDemand=false)]
    public class MyExternalModule : IModule
    {
        private readonly IUnityContainer container;
        public MyExternalModule(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this.container = container;
        }
        public void Initialize()
        {
            container.RegisterInstance(new MyService());
        }
    }

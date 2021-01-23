    public class HardwareModule : IModule
    {
        IUnityContainer _container;
        public HardwareModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<ICamera, Camera>();
        }
    }

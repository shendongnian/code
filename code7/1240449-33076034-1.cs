    public class HardwareConsumer
    {
        IUnityContainer _container;
        public HardwareConsumer(IUnityContainer container)
        {
            _container = container;
        }
        public async void TakePhoto()
        {
            ICamera camera = _container.Resolve<ICamera>();
            var result = await camera.TakePhoto;
        }
    }

    public class ClientModule : IModule
    {
        private readonly IUnityContainer _unityContainer;
        public ClientModule( IUnityContainer unityContainer )
        {
            _unityContainer = unityContainer;
        }
    }

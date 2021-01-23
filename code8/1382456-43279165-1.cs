    public class UnitiyLocator
    {
        private static readonly UnityContainer unityContainer;
        static UnitiyLocator()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<UnityViewModel>();
            unityContainer.RegisterType<IDataService, RuntimeDataService>();
        }
        public UnityViewModel UnityViewModel => unityContainer.Resolve<UnityViewModel>();
    }

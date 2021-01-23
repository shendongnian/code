    public static class IocContainer
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            // Possibly do registrations here as well...
            return container;
        });
    
        public static IUnityContainer Instance
        {
            get { return Container.Value; }
        }
    }

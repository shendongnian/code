    public static class IoC
    {
        public static IUnityContainer Unity { get; private set; }
        public static T Resolve<T>()
        {
            return Unity.Resolve<T>();
        }
        public static T Resolve<T>(string key)
        {
            return Unity.Resolve<T>(key);
        }
        public static void Initialize(IUnityContainer unity)
        {
            Unity = unity;
        }
    }

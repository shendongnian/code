    public static class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IServiceUserService , ServiceUserService>();
        }
    }

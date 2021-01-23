    public static class UnityHelper
    {
        public static void RegisterTypes<T>(IUnityContainer container)
        	where T : LifetimeManager
        {
            container.RegisterType<ISomething, Something>(Activator.CreateInstance<T>());
        }
    }

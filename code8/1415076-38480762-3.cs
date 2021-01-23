    public static class UnityExtensions
    {
        public static T TryResolve<T>(this IUnityContainer container, string name)
        {
            if (container.IsRegistered<T>(name))
                return container.Resolve<T>(name);
    
            return container.Resolve<T>();
        }
    }

    public static class ServiceProviderServiceExtensions
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }
    
        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetRequiredService(typeof(T));
        }
    }

    public static class ServiceProviderServiceExtensions
    {
        public static IServiceScope CreateScope(this IServiceProvider provider);
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType);
        public static T GetRequiredService<T>(this IServiceProvider provider);
        public static T GetService<T>(this IServiceProvider provider);
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider);
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType);
    }

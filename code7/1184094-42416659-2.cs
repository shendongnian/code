        public static class ServiceCollectionExtensions
        {
            public static void(this IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
            {
                var serviceDescriptor = services.FirstOrDefault(s => s.ServiceType == serviceType);
                var serviceIndex = services.IndexOf(serviceDescriptor);
                services.Insert(serviceIndex, new ServiceDescriptor(serviceType, implementationType, serviceLifetime));
                services.RemoveAt(serviceIndex + 1);
            }
        }

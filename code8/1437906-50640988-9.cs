     /// <summary>
        /// Adds the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the t service.</typeparam>
        /// <typeparam name="TImplementation">The type of the t implementation.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="instanceName">Name of the instance.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddSingleton<TService, TImplementation>(
            this IServiceCollection services,
            string instanceName
        )
            where TService : class
            where TImplementation : class, TService
        {
            var provider = services.BuildServiceProvider();
            var implementationInstance = provider.GetServices<TService>().LastOrDefault();
            if (implementationInstance.IsNull())
            {
                services.AddSingleton<TService, TImplementation>();
                provider = services.BuildServiceProvider();
                implementationInstance = provider.GetServices<TService>().Single();
            }
            return services.RegisterInternal(instanceName, provider, implementationInstance);
        }
        private static IServiceCollection RegisterInternal<TService>(this IServiceCollection services,
            string instanceName, ServiceProvider provider, TService implementationInstance)
            where TService : class
        {
            var accessor = provider.GetServices<IServiceAccessor<TService>>().LastOrDefault();
            if (accessor.IsNull())
            {
                services.AddSingleton<ServiceAccessor<TService>>();
                provider = services.BuildServiceProvider();
                accessor = provider.GetServices<ServiceAccessor<TService>>().Single();
            }
            else
            {
                var serviceDescriptors = services.Where(d => d.ServiceType == typeof(IServiceAccessor<TService>));
                while (serviceDescriptors.Any())
                {
                    services.Remove(serviceDescriptors.First());
                }
            }
            accessor.Register(implementationInstance, instanceName);
            services.AddSingleton<TService>(prvd => implementationInstance);
            services.AddSingleton<IServiceAccessor<TService>>(prvd => accessor);
            return services;
        }
        //
        // Summary:
        //     Adds a singleton service of the type specified in TService with an instance specified
        //     in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
        //     to.
        //   implementationInstance:
        //     The instance of the service.
        //   instanceName:
        //     The name of the instance.
        //
        // Returns:
        //     A reference to this instance after the operation has completed.
        public static IServiceCollection AddSingleton<TService>(
            this IServiceCollection services,
            TService implementationInstance,
            string instanceName) where TService : class
        {
            var provider = services.BuildServiceProvider();
            return RegisterInternal(services, instanceName, provider, implementationInstance);
        }
        /// <summary>
        /// Registers an interface for a class
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection As<TInterface>(this IServiceCollection services)
             where TInterface : class
        {
            var descriptor = services.Where(d => d.ServiceType.GetInterface(typeof(TInterface).Name) != null).FirstOrDefault();
            if (descriptor.IsNotNull())
            {
                var provider = services.BuildServiceProvider();
                var implementationInstance = (TInterface)provider?.GetServices(descriptor?.ServiceType)?.Last();
                services?.AddSingleton(implementationInstance);
            }
            return services;
        }

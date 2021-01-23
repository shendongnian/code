    /// <summary>
        /// Gets the implementation of service by name.
        /// </summary>
        /// <typeparam name="T">The type of service.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="serviceName">The service name.</param>
        /// <returns>The implementation of service.</returns>
        public static T GetService<T>(this IServiceProvider serviceProvider, string serviceName)
        {
            string fullnameImplementation = ServiceCollectionTypeMapper.Instance.GetService<T>(serviceName);
            if (fullnameImplementation == null)
            {
                throw new InvalidOperationException($"Unable to resolve service of type [{typeof(T)}] with name [{serviceName}]");
            }
            else
            {
                return (T)serviceProvider.GetService(Type.GetType(fullnameImplementation));
            }
        }

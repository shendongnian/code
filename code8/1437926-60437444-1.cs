     /// <summary>
    /// Allows to set the service register mapping.
    /// </summary>
    public class ServiceCollectionTypeMapper
    {
        private ServiceCollectionTypeMapper()
        {
            this.ServiceRegister = new Dictionary<string, Dictionary<string, string>>();
        }
        /// <summary>
        /// Gets the instance of mapper.
        /// </summary>
        public static ServiceCollectionTypeMapper Instance { get; } = new ServiceCollectionTypeMapper();
        private Dictionary<string, Dictionary<string, string>> ServiceRegister { get; set; }
        /// <summary>
        /// Adds new service definition.
        /// </summary>
        /// <param name="typeName">The name of the TService.</param>
        /// <param name="serviceName">The TImplementation name.</param>
        /// <param name="namespaceFullName">The TImplementation AssemblyQualifiedName.</param>
        public void AddDefinition(string typeName, string serviceName, string namespaceFullName)
        {
            if (this.ServiceRegister.TryGetValue(typeName, out Dictionary<string, string> services))
            {
                if (services.TryGetValue(serviceName, out _))
                {
                    throw new InvalidOperationException($"Exists an implementation with the same name [{serviceName}] to the type [{typeName}].");
                }
                else
                {
                    services.Add(serviceName, namespaceFullName);
                }
            }
            else
            {
                Dictionary<string, string> serviceCollection = new Dictionary<string, string>
                {
                    { serviceName, namespaceFullName },
                };
                this.ServiceRegister.Add(typeName, serviceCollection);
            }
        }
        /// <summary>
        /// Get AssemblyQualifiedName of implementation.
        /// </summary>
        /// <typeparam name="TService">The type of the service implementation.</typeparam>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>The AssemblyQualifiedName of the inplementation service.</returns>
        public string GetService<TService>(string serviceName)
        {
            Type serviceType = typeof(TService);
            if (this.ServiceRegister.TryGetValue(serviceType.Name, out Dictionary<string, string> services))
            {
                if (services.TryGetValue(serviceName, out string serviceImplementation))
                {
                    return serviceImplementation;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

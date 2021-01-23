      public class AppCapabilitiesRepository : IAppCapabilityRepository
        {
            private readonly Type _typeOfAppCapability = typeof (IAppCapability);
    
            public IList<IAppCapability> GetCapabilities()
            {
                var capabilities =  GetType().GetTypeInfo().Assembly.GetTypes().Where(IsAppCapability).ToArray();
                var viewModels = capabilities.Select(capability => ((IAppCapability)Activator.CreateInstance(capability)))
                    .Where(c => c.IsActive)
                    .OrderBy(c => c.Popularity).ToList();
                return viewModels;
            }
    
            private bool IsAppCapability(Type type)
            {
                var typeInfo = type.GetTypeInfo();
                return _typeOfAppCapability.IsAssignableFrom(type) && !typeInfo.IsAbstract && !typeInfo.IsInterface;
            }
        }

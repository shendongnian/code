      private readonly ConcurrentDictionary<string, Type> _dynamicTypesByName = 
          new ConcurrentDictionary<string, Type>();
      
      Type GetDynamicType(string typeName) {
        // define the module builder...
        ModuleBuilder module = ...
        return _dynamicTypesByName.GetOrAdd(typeName, MakeDynamicType);
      }

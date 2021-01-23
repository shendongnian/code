    public static IEnumerable<object> GetPluginsForModule<T>()
    {
        var type = typeof(T);
        var types = Plugins.SelectMany(s => s.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && x.IsClass).ToList();
        foreach (var t in types)
        {
            if (t.CustomAttributes.Where(x => x.AttributeType == typeof(CluraPlugin)).Any()) 
            {
               CustomAttributeData attr = t.CustomAttributes.Where(x => x.AttributeType == typeof(CluraPlugin)).FirstOrDefault();
               if (attr == null)
                  break;
               string Name = attr.ConstructorArguments.Where(x => x.ArgumentType == typeof(string)).FirstOrDefault().Value as string;
               Type InterfaceTypeArgument = attr.ConstructorArguments.Where(x => x.ArgumentType == typeof(Type)).FirstOrDefault().Value as Type;
               Container.Register(InterfaceTypeArgument, t, Name).AsMultiInstance();
             }
         }
         return Container.ResolveAll(type);
    }

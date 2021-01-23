     Assembly assembly = RuntimeContext.Current.LoadAssembly(assemblyPath);
     foreach (Type type in assembly.GetTypes())
     {
       if (type.GetCustomAttributes(true)
               .Select(x => (x as Attribute).GetType().FullName).Contains("PluginAttribute"))
          pluginTypes.Add(type, assemblyPath);
     }

     foreach (Type type in assembly.GetTypes())
     {
       if (type.GetCustomAttributes(true)
                .Any(ca=> typeof(PluginAttribute).IsAssignablefrom(ca.GetType())))
          pluginTypes.Add(type, assemblyPath);
     }

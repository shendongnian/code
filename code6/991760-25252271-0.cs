    Dictionary<Type, string> pluginTypes =
        (from assemblyPath in assemblyPaths
            let assembly = RuntimeContext.Current.LoadAssembly(assemblyPath)
            from type in assembly.GetTypes()
            let attribs = type.GetCustomAttributes(true)
            where attribs.Select(x => (x as Attribute).GetType().FullName)
            .Contains("PluginAttribute")
            select new
            {
                key = type,
                value = assemblyPath
            })
        .ToDictionary(pair => pair.key, pair => pair.value);

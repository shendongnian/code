    //register the plugins in the container
    var plugins = Directory.GetFiles(yourAppDirectory, "plugin_*.dll");
    foreach (var pluginDll in plugins)
    {
        var assembly = Assembly.Load(pluginDll);
        var pluginType = assembly.GetTypes().FirstOrDefault(x=> typeof(IPlugin).IsAssignableFrom(x));
        yourContainer.RegisterType(pluginType, typeof(IPlugin));
    }

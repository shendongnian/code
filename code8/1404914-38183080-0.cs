        var path = Path.Combine(
            Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
            "X.dll");
        var assembly = Assembly.LoadFrom(path);
        // Some operation with assembly

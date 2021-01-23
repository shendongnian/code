    var assembly = Assembly.GetAssembly(typeof (ICar));
    var typesInAssembly = assembly.GetTypes();
    var matching = typesInAssembly
        .Where(type => typeof(ICar).IsAssignableFrom(type) && !type.IsInterface);
    // Checking !type.IsInterface or else it also returns ICar.

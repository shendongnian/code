    // classes now an IEnumerable<Type> - no need for a list here.
    var classes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(y => type.IsAssignableFrom(y) && y.GetInterfaces().Contains(type));
    if (!classes.Any())

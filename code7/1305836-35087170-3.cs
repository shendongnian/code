    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a => a.GetTypes())
        .Where(x => typeof (IConfig).IsAssignableFrom(x) && !x.IsAbstract)
        .ToList();
    var objects = types.Select(x => x.GetFields().Single(y => x == y.FieldType).GetValue(null))
        .ToList();
    var fileNames = objects.Select(x => x.GetType().GetProperty("FileName").GetValue(x)).ToList();

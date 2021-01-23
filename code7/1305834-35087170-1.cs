    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(ad => ad.GetTypes())
        .Where(x => typeof (IConfig).IsAssignableFrom(x) && !x.IsAbstract)
        .ToList();
    var objects = types.Select(x => x.GetFields().Single(y => typeof (IConfig).IsAssignableFrom(y.FieldType)))
        .Select(x => x.GetValue(null)).ToList();
    var fileNames = objects.Select(x => x.GetType().GetProperty("FileName").GetValue(x)).ToList();

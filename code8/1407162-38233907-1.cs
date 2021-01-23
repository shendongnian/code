    var type = typeof(IBase);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
    var myObjects = new List<IBase>();
    foreach (var t in types)
    {
        myObjects.Add((IBase)Activator.CreateInstance(t));
    }

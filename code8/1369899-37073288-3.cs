    var type = typeof(IMarker);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p != type)
        .Where(p => type.IsAssignableFrom(p))
        .ToArray();
    var serializer = new XmlSerializer(obj.GetType(), types);

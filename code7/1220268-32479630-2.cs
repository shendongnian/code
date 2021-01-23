    var type = obj.GetType();
    var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    foreach(var prop in props)
    {
        Console.WriteLine("property: {0} type:{1}", prop.Name, prop.PropertyType);
    }

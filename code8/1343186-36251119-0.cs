    var types = this.GetType().Assembly.GetTypes()
                                       .Where(t=>t.GetInterfaces().Contains(typeof(IGetNews)));
    foreach (var type  in types)
    {
        var instance = (IGetNews) Activator.CreateInstance(type);
        instance.SomeNews("news");
    }

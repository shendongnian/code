    var type = Assembly.Load("AnotherAssembly")
        .GetTypes()
        .Where(t => t.IsAssignableFrom(typeof(ISample)))
        .Single();
    var instance = (ISample) Activator.CreateInstance(type);
    var result = instance.SampleMethod("test");

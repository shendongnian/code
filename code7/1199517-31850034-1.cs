    var type = Assembly.Load("AnotherAssembly")
        .GetTypes()
        .Where(t => t.IsAssignableFrom(typeof(ISample)))
        .Single();
    ISample instance = (ISample) Activator.CreateInstance(type);
    string result = instance.SampleMethod("test");

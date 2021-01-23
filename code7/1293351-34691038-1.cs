    // First get the assembly
    // In this example we load the currently executing assembly but
    // you can load any assembly you would need
    var assembly = Assembly.GetExecutingAssembly();
    // Then you could use the GetTypes method to get all types from
    // this assembly and then filter with LINQ
    List<Type> derived = assembly
        .GetTypes()
        .Where(t => t != typeof(Foo)) // we don't want Foo itself
        .Where(t => typeof(Foo).IsAssignableFrom(t)) // we want all types that are assignable to Foo
        .ToList();
    // at this stage derived will contain the Foo_Child and FooBar types

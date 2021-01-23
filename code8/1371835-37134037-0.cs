    builder.RegisterType<MyClass>().As<IMy>();
    builder.RegisterType<MyClass2>().As<IMy>();
    var container = builder.Build();
    var collection = container.Resolve<IEnumerable<IMy>>();
    Console.WriteLine(collection.Count()); // prints "2"

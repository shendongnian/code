    var a = Lifestyle.Singleton.CreateRegistration<MyClassA>(container);
    var b = Lifestyle.Singleton.CreateRegistration<MyClassB>(container);
    container.RegisterCollection<IInterface>(new[] { a, b });
    container.AddRegistration(typeof(IInterface<MyClassA>), a);
    container.AddRegistration(typeof(IInterface<MyClassB>), b);

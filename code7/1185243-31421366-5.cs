    IUnityContainer container = new UnityContainer();
    // Add container extension
    container.AddNewExtension<RegistrationTrackingExtension>();
    // Register types
    container.RegisterType<MyClass>();
    container.RegisterType<IMyClass, MyClass>();
    container.RegisterType<IMyClass, MyClass>("A");
    // These succeed because they were explicitly registered
    container.Resolve<IMyClass>();
    container.Resolve<IMyClass>("A");
    container.Resolve<MyClass>();
    // MyClass2 was not registered so this will throw an exception
    container.Resolve<MyClass2>();

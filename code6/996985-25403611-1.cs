    // using SimpleInjector.Extensions.ExecutionContextScoping;
    using (container.BeginExecutionContextScope())
    {
        var initializer = container.GetInstance<MyDbInitializer>();
        intializer.InitializeDatabase();
    }

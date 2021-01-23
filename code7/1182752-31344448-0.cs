    // using SimpleInjector.Lifestyles;
    using (AsyncScopedLifestyle.BeginScope(container)) {
        var service = container.GetInstance<ISomeService>();
        // ...
    }

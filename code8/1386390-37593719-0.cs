    // Registrations
    // One registration for the open generic type
    c.Register(typeof(ICheckRepository<>), typeof(CheckRepository<>));
    // One registration for the connection string (assuming you only have one)
    container.RegisterConditional(typeof(string), CreateStringConstant(constr),
        c => c.Consumer.Target.Name == "connectionString");
    // Conditional registrations for each closed ICheckRepository<T>
    RegisterStoredProcForCheckRepository<Customer>("cuts_sp");
    RegisterStoredProcForCheckRepository<Order>("order_sp");
    RegisterStoredProcForCheckRepository<Product>("prod_sp");
    // more registrations here
    // Helper methods
    Registration CreateStringConstant(string value) =>
        Lifestyle.Singleton.CreateRegistration(typeof(string), () => value, container);
    void RegisterStoredProcForCheckRepository<TEntity>(string spName) {
        container.RegisterConditional(typeof(string), CreateStringConstant(container, spName),
            c => c.Consumer.Target.Name == "segment"
                && c.Contumer.ImplementationType == typeof(CheckRepository<TEntity>));
    }

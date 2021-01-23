    builder.EntitySet<Customer>("Customers")
        .EntityType.Collection.Action("IsEmailAvailable")
        .Returns<bool>()
        .Parameter<string>("email");
    
    builder.EntitySet<Customer>("Customers")
        .EntityType.Action("IsEmailAvailable").Returns<bool>()
        .Parameter<string>("email");

    builder.RegisterType<DatabaseA_Context>()
           .Named<DbContext>("databaseA")
           .InstancePerLifetimeScope();
    builder.RegisterType<DatabaseB_Context>()
           .Named<DbContext>("databaseB")
           .InstancePerLifetimeScope();

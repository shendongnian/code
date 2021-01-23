    // Context connected to local database
    var dbConfig = Configuration<DBContext>.Build
       .Context(DBContext.Configure
          .Adapter(DatabaseAdapter.Configure
             .DatabaseConfiguration(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(@"<your conn str>")
             )
             .SearchProvider(new YourSearchProvider()) // <--- Pass in an instance of your search provider
          )
          .Identity(() => new AuthIdentity(new Guid("c52a2874-bf95-4b50-9d45-a85a84309e75"), "Mike"))
       ).Create();

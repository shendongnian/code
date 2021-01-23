    Bind<ISessionFactory>().ToMethod(
        e => 
        {
            var x1 = Fluently.Configure();
            var x2 = x1.Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("JustBlogDbConnString")));
            var x3 = x2.Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>());
            var x4 = x3.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Post>());
            var x5 = x4.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false));
            var x6 = x5.BuildConfiguration();
            x6.BuildSessionFactory();
        })
        .InSingletonScope();

    private FluentConfiguration CreateConfiguration(IPersistenceConfigurer configurer)
            {
                return Fluently.Configure()
                    .Database(configurer)
                    .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Userclaim>())
                    .ExposeConfiguration(x => x.SetInterceptor(new SqlStatementInterceptor()));
            }
    
            private IPersistenceConfigurer CreateTestDatabaseConfiguration()
            {
                return SQLiteConfiguration
                    .Standard
                    .InMemory()
                    .ShowSql();
            }

    FluentConfiguration configuration = Fluently.Configure()
                             .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
                             .ExposeConfiguration(cfg => cfg
                                .SetProperty("command_timeout", "100")
                             .Mappings(m =>
                             {
                                 var cfg = CreateAutomappings();
                                 m.AutoMappings.Add(cfg);
                             });

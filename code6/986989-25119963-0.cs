    cfg.Configure(); // read config default style
    
                var mappings = AutoMap.AssemblyOf<ClasseTest>(new AutoMapConfiguration());
                mappings.WriteMappingsTo(@"c:\mappings");
    
                Fluently.Configure(cfg)
                    .Mappings(m => m.AutoMappings.Add(mappings))
                    .ExposeConfiguration(config => new SchemaExport(config).Create(false, true));       
                _sessionFactory = cfg.BuildSessionFactory();

    builder.RegisterDecorator<IHeaderMappingRepository>(
                          (c, inner) => new CachedHeaderMappingRepository(inner), 
                          fromKey: "headerMappingRepository")
           .As<IHeaderMappingRepository>();
    builder.RegisterType<SqlHeaderMappingRepository>()
           .Named<IHeaderMappingRepository>("headerMappingRepository");
    builder.Register(c => new CachedHeaderMappingRepository(
                          c.ResolveNamed<IHeaderMappingRepository>("headerMappingRepository")))
           .As<IHeaderMappingRepository>();
    builder.RegisterType<SqlHeaderMappingRepository>()
           .Named<IHeaderMappingRepository>("headerMappingRepository"));

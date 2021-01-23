    using (var db = new Context())
    {
        var mapping = EfMappingFactory.GetMappingsForContext(db);
        var commentMapping = mapping.TypeMappings[typeof(Comment)];
    }

    
    config.CreateMap<DefinitionWebObject, DefinitionBusinessObject>();  // Create sub-mapping first.
    config.CreateMap<BusinessObject, WebObject>()
        .ForMember(d => d.Component, opts => opts.ResolveUsing(b =>
        {
            return new ComponentBusinessObject()
            {
                Date = b.Property1.Date,
                Definition = Mapper.Map<DefinitionBusinessObject>(b.Property2.Definition)
            };
        }));

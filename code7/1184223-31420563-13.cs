    Entity entity = new Entity();
    ...
    entity.Properties = new Dictionary<string, object>
    {
        {"IntProp", 9},
        {"DateTimeOffsetProp", new DateTimeOffset(2015, 7, 16, 1, 2, 3, 4, TimeSpan.Zero)}
    };
    
    container.Configurations.RequestPipeline.OnEntryStarting(args =>
    {
        foreach (var property in entity.Properties)
        {
            args.Entry.AddProperties(new ODataProperty
            {
                Name = property.Key,
                Value = property.Value
            });
        }
    });
    
    container.AddToEntities(entity);
    container.SaveChanges();

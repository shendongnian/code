    var settings = new ConnectionSettings(uri: new Uri("http://localhost:9200/"));
    var client = new ElasticClient(settings);
    var templateResponse = client.GetTemplate("sometemplate");
    var template = templateResponse.TemplateMapping;
    // Don't delete, this way other settings will stay intact and the PUT will override ONLY the mappings.
    // client.DeleteTemplate("sometemplate");
    // Add a mapping to the template like this...
    PutMappingDescriptor<SomeNewType> mapper = new PutMappingDescriptor<SomeNewType>(settings);
    mapper.MapFromAttributes();
    RootObjectMapping newmap = ((IPutMappingRequest) mapper).Mapping;
    TypeNameResolver r = new TypeNameResolver(settings);
    string mappingName = r.GetTypeNameFor(typeof(SomeNewType));
    template.Mappings.Add(mappingName, newmap);
    var putTemplateRequest = new PutTemplateRequest("sometemplate")
    {
        TemplateMapping = template
    };
    var result = client.PutTemplate(putTemplateRequest);

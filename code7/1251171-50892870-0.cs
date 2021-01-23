    JSchemaGenerator generator = new JSchemaGenerator();
    JSchema schema = generator.Generate(typeof(QueryValueDataModel));
    JObject o = JObject.Parse(jsonstr);
    if(o.IsValid(schema))
    {
        QueryValueDataModel deserialized = o.ToObject(typeof(QueryValueDataModel));
    }
    else
    {
        throw new Exception("schema dosn't match");
    }

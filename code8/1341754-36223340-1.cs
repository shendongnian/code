    var deserializeSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        TypeNameAssemblyFormat = FormatterAssemblyStyle.Full,
        Formatting = Formatting.Indented,
        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
    };
    JsonConvert.PopulateObject(serializedObject, newDic, deserializeSettings);

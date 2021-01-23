    var settings = new JsonSerializerSettings {
        TypeNameHandling = TypeNameHandling.Objects
    };
    string serial = JsonConvert.SerializeObject(sample_list, settings);
    List<object> list =
        JsonConvert.DeserializeObject<List<object>>(serial, settings);

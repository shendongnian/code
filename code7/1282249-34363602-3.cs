    var data = JsonConvert.DeserializeObject<ObjectDataList>(jsonData);
    var rows = new List<DeserializedData>();
    foreach (dynamic item in data)
    {
        var newData = new DeserializedData();
        foreach (dynamic prop in item)
        {
             var row = new KeyValuePair<string, string>
             (prop.Name.ToString(), prop.Value.ToString());
             newData.Add(row);
        }
        rows.Add(newData);
    }

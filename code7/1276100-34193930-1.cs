    var rootValue = JsonValue.Parse(jsonString);
    foreach (var item in rootValue.GetArray())
    {
        var unamedObject = item.GetObject();
        var personObject = unamedObject["person"].GetObject();
        System.Diagnostics.Debug.WriteLine(personObject["name"].GetString());
        System.Diagnostics.Debug.WriteLine(personObject["country"].GetString());
        System.Diagnostics.Debug.WriteLine(personObject["city"].GetString());
        System.Diagnostics.Debug.WriteLine(personObject["phone"].GetString());
    }

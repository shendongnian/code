    var jsonData = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(jsonString);
    Dictionary<string, Dictionary<string, List<Dictionary<string, string>>>> finalData;
    // I could have just done var finalData = ... here.  I declared finalData explicitly to makes its type clear.
    finalData =
        jsonData.ToDictionary(
        p1 => p1.Key,
        p1 => p1.Value
            .AsJsonObject()
            .ToDictionary(
                p2 => p2.Key,
                p2 => (p2.Value.IsJsonObject() 
                    ? new[] { p2.Value.AsJsonObject() } 
                    : p2.Value.AsJsonArray().Select(a => a.AsJsonObject())).Select(o => o.ToDictionary(p3 => p3.Key, p3 => p3.Value.JsonPrimitiveToString())).ToList()
            ));

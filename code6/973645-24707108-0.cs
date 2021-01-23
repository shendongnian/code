    // You simply deserialize the entire response to an ExpandoObject
    // so you don't need a concrete type to deserialize the whole response...
    dynamic responseEntity = JsonConvert.DeserializeObject<ExpandoObject>(
                                 googlePlacesJson, new ExpandoObjectConverter()
                             );
    
    // Now you can access result array as an `IEnumerable<dynamic>`...
    IEnumerable<dynamic> results = responseEntity.results;
    
    foreach(dynamic result in results)
    {
       // Do stuff for each result in the whole response...
    }

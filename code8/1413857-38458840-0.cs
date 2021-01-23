    string ObjectsToTable(string collectionJson)
    {
        // reading the collection from passed JSON string
        JArray collection = JArray.Parse(collectionJson);
        // retrieving header as a list of properties from the first element
        // it is assumed all other elements have the exact same properties
        List<string> header = (collection.First as JObject).Properties().Select(p => p.Name).ToList();
        // retrieving values as lists of strings
        // each string is corresponding to the property named in the header
        List<List<string>> values = values = collection.Children<JObject>().Select( o => header.Select(p => o[p].ToString()).ToList() ).ToList();
        
        // passing the table structure with the header and values
        return JsonConvert.SerializeObject(new { Header = header, Values = values });
    }

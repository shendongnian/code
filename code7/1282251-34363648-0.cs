    var data = JsonConvert.DeserializeObject<dynamic>(jsonData);
    var rows = new List<string>();
    // Go through the overall object, and get each item in 
    // the array, or property in a single object.
    foreach (KeyValuePair<string, object> item in data)
    {
        dynamic obj = item.Value;
        var row = "";
        // Perhaps add a check here to see if there are more
        // properties (if it is an item in an array). If not
        // then you are working with a single object, and each
        // item is a property itself.
        foreach (KeyValuePair<string, object> prop in obj)
        {
            // Very dummy way to demo adding to a CSV
            string += prop.Value.ToString() + ",";
        }
        rows.Add(string);
    }

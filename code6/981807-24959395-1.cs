    // Using JSON.NET you can deserialize the JSON array as an enumerable 
    // of dynamically-typed objects (i.e. your array)
    IEnumerable<dynamic> employees = JsonConvert
                                       .DeserializeObject<IEnumerable<dynamic>>
                                       (
                                           jsonText
                                       );
    
    Dictionary<string, object> values = new Dictionary<string, object>();
    
    foreach(dynamic employee in employees) 
    {
        values.Add((string)employee.Position, (object)employee.Salary);
    }
    
    // .NET dictionaries are deserialized into JSON objects!
    string convertedJson = JsonConvert.SerializeObject(values);

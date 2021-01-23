    Dictionary<string, string> myDictionary = new Dictionary<string, string> { { "1", "A" }, { "2", "B" } };
    
    //Serialize Dictionary to string and store in file
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(myDictionary);
    System.IO.File.WriteAllText(@"C:\Docs\json.txt", json);
    
    //Read serialized dictionary json string and Deserialize to Dictionary object
    string jsonString = System.IO.File.ReadAllText(@"C:\Docs\json.txt");
    Dictionary<string, string> deserializedDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

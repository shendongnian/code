    var settings = new JsonSerializerSettings() { 
                      TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
                   };
    string s = JsonConvert.SerializeObject(vehicles, settings);
    List<Vehicle> deserialized = JsonConvert.DeserializeObject<List<Vehicle>>(s,settings);
    foreach (Vehicle v in deserialized)
    {
        Console.WriteLine("After deserializing, we have a: " + v.GetType());
    }

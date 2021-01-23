    public static List<Definitions> GetData()
    { 
        var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        var allDefinitions = JsonConvert.DeserializeObject<MainList>(f);
 
        return allDefinitions.data;
    }

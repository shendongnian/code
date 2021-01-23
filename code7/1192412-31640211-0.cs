    var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            
    var str = JsonConvert.SerializeObject(null,settings); 
    var obj1 = JsonConvert.DeserializeObject(str, settings);
    str = JsonConvert.SerializeObject("value", settings);
    var obj2 = JsonConvert.DeserializeObject(str, settings);
    str = JsonConvert.SerializeObject("", settings);
    var obj3 = JsonConvert.DeserializeObject(str, settings);

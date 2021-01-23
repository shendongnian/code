    var json = "{\"timestamp\":\"2016-06-16T16:27:36.808Z\"}";
    var jsonSerializerSettings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.None };
    var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json, jsonSerializerSettings);
    var obj = dict["timestamp"];
    Console.WriteLine(obj);

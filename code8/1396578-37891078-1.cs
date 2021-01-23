    var obj = JsonConvert.DeserializeObject<RootObject>(oldString);
    Console.WriteLine(obj.rgDescriptions["310776560_302028390"].icon_url); // e.g.
    var newString = JsonConvert.SerializeObject(obj,
         new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    // null value handling is optional, the above makes it a little more like the source string

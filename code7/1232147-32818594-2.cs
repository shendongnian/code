    var jObject = JObject.Parse(json);
    var names = new List<string> 
    { 
        jObject["Names"].Value<string>("string")
    };
    var types = jObject["ClassTypes"]["Types"]
        .Select(x => new Types
        {
            TypeId = x.Value<int>("TypeId"),
            TypeName = x.Value<string>("TypeName")
        })
            .ToList();
    var data = new MyClass(names,types)
    {
        Id = jObject.Value<int>("Id"),
        Status = (StatusType)Enum.Parse(typeof(StatusType),jObject.Value<string>("Status")),
        DOB = DateTime.ParseExact(jObject.Value<string>("DOB"), @"dd\/MM\/yyyy", null)
    };
    
    Console.WriteLine(data);

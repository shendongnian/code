    var parent = JsonConvert.DeserializeObject<JObject>(raw);
    ((JArray)parent.Property("results").Value)
        .Select(jo => (JObject)jo)
        .ToList()
        .ForEach(x => 
            x
                .Properties()
                .ToList()
                .ForEach(p =>
                {
                    if (p.Name != "name")
                        p.Remove();
                }))
        //.Dump();
        ;

    var root = (JContainer)JToken.Parse(jsonString);
    var query1 = from o in root.DescendantsAndSelf().OfType<JObject>()      // Find objects
                 let l = o.Properties().Where(p => p.Value is JValue)       // Select their primitive properties
                 where l.Any()                                              // Skip objects with no properties
                 select l.ToDictionary(p => p.Name, p => (string)p.Value);  // And return a dictionary.
    var list1 = query1.ToList();

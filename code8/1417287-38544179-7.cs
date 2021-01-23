    var query2 = from o in root.DescendantsAndSelf().OfType<JObject>()      // Find objects
                 let l = o.Properties().Where(p => p.Value is JValue)       // Select their primitive properties
                 where l.Any()                                              // Skip objects with no properties
                 // Add synthetic "Parent" property
                 let l2 = l.Concat(new[] { new JProperty("Parent", o.Ancestors().OfType<JProperty>().Select(a => a.Name).FirstOrDefault() ?? "") })
                 select new JObject(l2);                                    // And return a JObject.
    var list2 = query2.ToList();

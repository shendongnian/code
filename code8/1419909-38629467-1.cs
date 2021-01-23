    List<JObject> list = 
        JObject.Parse(json)
               .Descendants()
               .Where(jt => jt.Type == JTokenType.Property && ((JProperty)jt).Value.HasValues)
               .Cast<JProperty>()
               .Select(prop =>
               {
                   var obj = new JObject(new JProperty("Name", prop.Name));
                   if (prop.Value.Type == JTokenType.Array)
                   {
                       var items = prop.Value.Children<JObject>()
                                             .SelectMany(jo => jo.Properties())
                                             .Where(jp => !jp.Value.HasValues);
                       obj.Add(items);
                   }
                   var parentName = prop.Ancestors()
                                        .Where(jt => jt.Type == JTokenType.Property)
                                        .Select(jt => ((JProperty)jt).Name)
                                        .FirstOrDefault();
                   obj.Add("Parent", parentName ?? "");
                   return obj;
               })
               .ToList();

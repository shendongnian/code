            var obj = JObject.Parse(jsonExample);
            var lstSSK = (from property in obj.Properties()
                          select new SSKChanges
                          {
                              SskSource = property.Name,
                              SskStatus = property.Value.Children<JProperty>().Select(p2 => p2.Name).FirstOrDefault(),
                              SskStatusBool = property.Value.Children<JProperty>().Select(p2 => (bool?)p2.Value).FirstOrDefault()
                          }).ToList();

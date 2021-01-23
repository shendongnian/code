            var res = JArray.Parse(JObject.Parse(text)["Nodes"].ToString());
            foreach (var o in res.Children<JObject>())
            {
                foreach (var property in o.Properties())
                {
                    Console.WriteLine(property.Name + " " + property.Value);
                }
            }

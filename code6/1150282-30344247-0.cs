       var json = JArray.Parse(s);
            foreach (JObject obj in json.Children<JObject>())
            {
                foreach (JProperty property in obj.Properties())
                {
                    
                    if (property.Value as JArray!=null)
                    {
                        var jsonArray = JArray.Parse(property.Value.ToString());
                         Console.WriteLine(property.Name + ":");
                        foreach(JObject o in jsonArray.Children<JObject>())
                            foreach(JProperty p in o.Properties())
                            {
                                Console.WriteLine(p.Name + " " + p.Value.ToString());
                            }
                    }
                    else
                    {
                        string name = property.Name;
                        string value = property.Value.ToString();
                        Console.WriteLine(name + " " + value);
                    }
                }
            }

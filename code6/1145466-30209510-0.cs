    var incidents = xdoc.Root
                        .Element("array")
                        .Elements("item")
                        .Select(i => i.Element("map")
                                      .Elements("item")
                                      .ToDictionary(m => m.Attribute("key").Value,
                                                    m => m.Value))
                        .Where(i => i.ContainsKey("mrid")
                                 && i.ContainsKey("mrtitle"))
                        .Select(i => new Incident
                                     {
                                         ID = int.Parse(i["mrid"]),
                                         Title = i["mrtitle"]
                                     });

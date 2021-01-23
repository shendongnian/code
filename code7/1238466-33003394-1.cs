    data.Descendants("Unit")
                    .Select<XmlElement, Unit>(x => new Unit() 
                    { 
                        Name = x.Attribute("Name").Value,
                        Prefixes = x.Descendants("Prefix").Select<XmlElement, Prefix>(p => new Prefix() 
                        {
                            Char = p.Attribute("Char").Value,
                            Factor = Convert.ToDouble(p.Attribute("Factor").Value),
                            IsSelectd = p.Attribute("IsSelected").Value == "true",
                            IsFixed = p.Attribute("IsFixed").Value == "true",
                            Func = p.Attribute("Func").Value
                        }).ToList()
                    })
                    .Select<Unit, KeyValuePair<string, Unit>>(unit => new KeyValuePair<string, Unit>() 
                    {
                        Key = x.Name,
                        Value = x 
                    })
                    .ToList()
                    .ForEach( kvp => {
                        Form.Units.Add(kvp.Key, kvp.Value);
                    });

     Form.Units = (data.Descendants("Unit").Select(x => new Unit
                     (
                        x.Attribute("Name").Value,
                        //(List<Prefix>) no casting needed
                        x.Descendants("Prefix").Select(p => new Prefix(
                            p.Attribute("Char").Value,
                            Convert.ToDouble(p.Attribute("Factor").Value),
                            p.Attribute("IsSelected").Value == "true",
                            p.Attribute("IsFixed").Value == "true",
                            p.Attribute("Func").Value)
                         ).ToList() // you had an IEnumerable<Prefix> now this is a List<Prefix>
                      )
                    )
               ).ToDictionary(x => x.Name, x => x);

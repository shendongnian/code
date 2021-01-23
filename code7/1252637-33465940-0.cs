    Property p = new Property
                   {
                      Name = (string)doc.Root.Element("Name"),
                      Buildings = doc.Root.Elements("Building")
                                     .Select(x => new Building
                                      {
                                         Name = (string)x.Element("Name"),
                                         Tenants = x.Elements("Tenant")
                                                    .Select(t => new Tenant
                                                     {
                                                         Name = (string)t.Element("Name"),
                                                         SF = (int)t.Element("SquareFeet"),
                                                         Rent = (decimal)t.Element("Rent")
                                                     }).ToList()
                                       }).ToList()
                    };

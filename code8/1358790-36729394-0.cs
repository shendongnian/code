    var xDoc = XDocument.Load(filename);
    var res  = xDoc.Descendants("Module")
                .Select(m => new
                {
                    Name = (string)m.Attribute("Name"),
                    CreditVal = (int)m.Attribute("CreditVal"),
                    Assignments = m.Descendants("Assignment")
                                    .Select(a => new
                                    {
                                        Name = (string)a.Attribute("Name"),
                                        Score = (int)a.Attribute("Score"),
                                        Weight = (int)a.Attribute("Weight")
                                    })
                                    .ToList()
                })
                .ToList();

      var result = linqDoc.Descendants()
                          .GroupBy(elem => elem.Name)
                          .ToDictionary(
                                        g => g.Key.ToString(), 
                                        g => g.Attributes("Id").Select(attr => attr.Value).ToList()
                                       );

                xmlDoc = XDocument.Parse(sr.ReadToEnd());
                IEnumerable<spl> result = from c in xmlDoc.Descendants("spl")
                                          select new spl()
                                                      {
                                                          setid = (string)c.Elements("setid"),
                                                          spl_version = (string)c.Elements("spl_version"),
                                                          title = (string)c.Elements("title"),
                                                          published_date = (string)c.Elements("published_date")
                                                      };

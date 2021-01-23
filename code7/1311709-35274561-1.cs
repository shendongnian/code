    XDocument xdoc = XDocument.Load("http://api.eve-central.c...
    var result = xdoc.Root.Elements("type")
                     .Select(ms => new MarketStat
                        {
                            Name = (string)ms.Attribute("id"),
                            MarketValueses = ms.Elements()
                                          .Select(mv => new MarketValue
                                             {
                                                 Volume = (long)mv.Element("volume"),
                                                 Avg = (double)mv.Element("avg"),
                                                 Max = (double)mv.Element("max"),
                                                 Min = (double)mv.Element("min"),
                                                 Stddev = (double)mv.Element("stddev"),
                                                 Median = (double)mv.Element("median"),
                                                 Percentile = (double)mv.Element("percentile")
                                             }).ToArray()
                                 }).ToList();

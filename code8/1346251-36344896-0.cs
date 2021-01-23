                Dictionary<DateTime, XElement> dict1 = doc.Elements("change")
                    .GroupBy(x => DateTime.Parse(x.Attribute("datetime").Value), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<DateTime, List<XElement>> dict2 = doc.Elements("change")
                    .GroupBy(x => DateTime.Parse(x.Attribute("datetime").Value), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());

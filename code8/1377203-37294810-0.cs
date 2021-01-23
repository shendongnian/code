            var xDoc = XDocument.Load("sample1.xml");
            var sections = xDoc.Root.Descendants("section")
                              .Select(x => new Section
                              {
                                  Name = x.Attribute("name").Value,
                                  Preference = GetPreference(x)
                              }).ToList();
        
      private static List<Preference> GetPreference(XElement x)
        {
            return x.Descendants("preference").Select(y => new Preference
                                                {
                                                    Name = y.Attribute("name").Value,
                                                    Default = ConvertToBool(y.Descendants("default").FirstOrDefault().Attribute("value").Value)
                                                }).ToList();
        }
        private static bool ConvertToBool(string trueOrFalse)
        {
            return trueOrFalse == "true" ? true : false;
        }

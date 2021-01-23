    static void Main(string[] args)
            {
                string searchText = "eee";
                XDocument xDocument = XDocument.Load(@"test.xml");
                var videos = from element in xDocument.Descendants("VIDEO").
                             Where(e => e.Descendants("ACTORS").
                             Descendants("ACTOR").Any(actor => actor.Element("NAME").Value.ToLower().Contains(searchText.ToLower())))
                             select new
                             {
                                 Id = element.Element("ID").Value,
                                 Name = element.Element("NAME").Value,
                                 Actors = element.Element("ACTORS").Descendants("ACTOR").Select(y => new
                                 {
                                     name = y.Element("NAME").Value,
                                     url = y.Element("URL").Value
                                 })
                             };
            }

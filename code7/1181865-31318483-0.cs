    static void GetNewXml()
            {
                string xml = @"<authors>
      <author name=""John"">
        <books>
           <book type=""Children"">ABC</book>
        </books>
      </author>
      <author name=""May"">
        <books>
           <book type=""Children"">A beautiful day</book>
        </books>
      </author>
      <author name=""John"">
        <books>
           <book type=""Fiction"">BBC</book>
        </books>
      </author>
    </authors>";
                XElement root = XElement.Parse(xml);
                var query = from e in root.Elements("author")
                            group e by e.Attribute("name").Value into g
                            select new XElement("author", new XAttribute("name", g.Key),
                                new XElement("books", g.Select(x => x.Element("books").Elements("book")).ToArray()));
                XElement newRoot = new XElement("authors", query.ToArray());
                Console.WriteLine(newRoot);
            }

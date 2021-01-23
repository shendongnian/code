    XDocument doc = XDocument.Load(ungrouped.xml);
    var groupedAuthors = doc.Root.Elements("author")
                            .GroupBy(a => a.Attribute("name").Value, 
                                     a => a.Descendants("book"))
                            .Select(g => new XElement("author", new XAttribute("name", g.Key,
                                                                new XElement("books", g.ToArray())
                                                     )
                                    );
    XElement root = new XElement("authors", groupedAuthors);

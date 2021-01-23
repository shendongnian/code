    var doc = XDocument.Load("all-courses.xml");
            
    var elements = doc.Root.Elements("Course")
        .GroupBy(c => c.Element("Track").Value)
        .Select(o =>
            new XElement(
                "Track",
                o.OrderBy(c => c.Element("Code").Value),
                new XAttribute("name", o.Key)));
    var new_doc = new XDocument(new XElement("Courses", elements));
    new_doc.Save("result.xml");

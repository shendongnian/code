    var doc = XDocument.Load("all-courses.xml");
            
    var elements = doc.Root.Elements("Course")
        .GroupBy(c => c.Element("Track").Value)
        .Select(o => //For each group create a new XElement
        {
            var element = new XElement("Track", o.OrderBy(c => c.Element("Code").Value));
            element.SetAttributeValue("name", o.Key);
            return element;
        }); 
    var new_doc = new XDocument(new XElement("Courses", elements));
    new_doc.Save("result.xml");

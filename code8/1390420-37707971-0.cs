    var doc = XDocument.Load(@"C:\Book1.xml");
    doc.Root.Add(XDocument.Load(@"C:\Book2.xml").Root.Elements()); // merged
    var sum = doc.Descendants("bookSum").Attributes("number").Sum(t => int.Parse(t.Value));
          
    var xElement = new XElement("bookSum", new XAttribute("number", sum));
    foreach(var attrib in doc.Descendants("bookSum").Attributes())
    {
         if (xElement.Attribute(attrib.Name) == null)
             xElement.Add(attrib);
    }
    doc.Descendants("bookSum").ToList().ForEach(t => t.ReplaceWith(xElement));
    doc.Root.Descendants("bookSum").First().Remove();
    Console.WriteLine(doc);

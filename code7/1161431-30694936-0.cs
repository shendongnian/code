    var items = (from node in System.Xml.Linq.XElement.Parse(xml).Elements("Book")
                         let subject = node.Element("Subject")
                         select new
                         {
                             Subject1 = subject.Element("Subject1"),
                             Subject2 = subject.Element("Subject2")
    
                         }).ToList();

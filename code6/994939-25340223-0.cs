    var evt = (from el in doc.Descendants("test")
	           where el.Parent.Name == "Event_1"
               group el by el.Parent.Element("NameOfEvent").Value into g
			   select new {
			       Name = g.Key,
				   Tests = g.Select(x => new {
                       XPath = x.Element("xpath").Value,
                       Value = x.Element("value").Value,
                       TagName = x.Element("tagName").Value
				   })
			   }).FirstOrDefault();
    
    Console.WriteLine("Event name: " + evt.Name);
    foreach (var test in evt.Tests)
    {
        Console.WriteLine(test.XPath);
        Console.WriteLine(test.Value);
        Console.WriteLine(test.TagName);
    }

	XElement xdoc = XElement.Load(@"XMLFile1.xml");
	var lines = from item in xdoc.Descendants("line")
	            select new
	            {
	                Description = item.Elements("field").Where(e => (string)e.Attribute("name") == "Description").First().Value,
	                Type = item.Elements("field").Where(e => (string)e.Attribute("name") == "Type").First().Value
	            };
	var array = lines.ToArray();
	foreach (var item in array)
	{
	    Console.WriteLine($"{item.Description}\t{item.Type}");
	}

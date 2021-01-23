    ......
    doc = XDocument.Load(reader);
    var data = doc.Root
    			  .Elements()
    			  .Elements("Payments");
    foreach(var d in data)
    {
    	var patti = d.Element("Patti");
    	list1.Add(new List<string>()
    			 { 
    				patti.Attribute("Rent").Value, 
    				patti.Attribute("Water").Value, 
    				patti.Attribute("Electricity").Value, 
    				patti.Attribute("Internet").Value 
    			 });
    			 
    	var mike = d.Element("Mike");
    	list2.Add(new List<string>() 
    			 { 
    				mike.Attribute("Rent").Value, 
    				mike.Attribute("Water").Value, 
    				mike.Attribute("Electricity").Value, 
    				mike.Attribute("Internet").Value 
    			 });
    }
    ......

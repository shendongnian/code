    //get the xml doc
    const string str = @"<root>
						   <Parameter1>3</Parameter1>
			    		   <Parameter2>4</Parameter2>
						 </root>";
		
    var xml = new XmlDocument();
    //load it
	xml.LoadXml(str);
		
    //get the nodes where the names contain the string parameter
	var xnList = xml.SelectNodes("//*[contains(name(),'Parameter')]");
		
    //create a list of parameters
	var list = new List<Parameter>();
		
    //populate the list with the value in the node's innertext
	foreach (XmlNode xn in xnList)
	{
		list.Add(new Parameter{ Value = int.Parse(xn.InnerText) } );
	}      
		
	foreach(var param in list)
		Console.WriteLine(param.Value); //should print 3 and 4

    XDocument Document = XDocument.Load("Cards.xml");
    var xns = XNamespace.Get("http://tempuri.org/CardSchema.xsd");
    var Elements = Document.Root.Elements(xns + "Card");
    foreach (var Card in Elements)
    {
    	// Process card information here
    
    	foreach (var item in Card.Elements())
    	{
    		Console.WriteLine("{0}: {1}", item.Name.ToString(), item.Value);
    	}
    }
    
    Console.ReadKey();

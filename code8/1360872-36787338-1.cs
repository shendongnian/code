    foreach (XElement el in address)
    {
    	var newElement = new XElement(
    							el.Name.LocalName,
    							el.Attributes(),
    							el.Elements().Where(o => o.Name.LocalName != "Address")
    					 );
    	Console.WriteLine(newElement.ToString());
    }

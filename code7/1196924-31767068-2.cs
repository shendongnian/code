    var xdoc = XDocument.Load(@"c:\temp\animals.xml");
    var el = xdoc.Elements().FirstOrDefault();
    var datas =
	    from data in el.Elements()
 	    select new { Number = data.Element("NUMBER").Value, Name = data.Element("NAME").Value, Price = data.Element("PRICE").Value} ;
    var xdoc2 = XDocument.Load(@"c:\temp\animals2.xml");
    var el2 = xdoc2.Elements().FirstOrDefault();
    var datas2 =
	    from data in el2.Elements()
 	    select new { Number = data.Element("NUMBER").Value, Name = data.Element("NAME").Value, Price = data.Element("PRICE").Value };
    var result = datas.Select(x =>
    {
	    var d2 = datas2.FirstOrDefault(y => y.Number == x.Number);
 	    if ( d2 != null)
	    {
		    return string.Format("{0} - price {1}", d2.Name, d2.Price);
	    }
	    return string.Format("{0} - price {1}", x.Name, x.Price);
    });
    //and result has IEnumerable<string> with the output
    Gorilla - 1240
    Bengal - 2500 
    Elephant - 4810 
    Zebra - 5600 

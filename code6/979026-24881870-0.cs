    XDocument xmldoc = XDocument.Parse(chkData);
    var emptyNodes = xmldoc.Descendants().Where(o => o.IsEmpty).ToList();
    foreach (XElement n in emptyNodes)
    {
    	n.Remove();
    }
    //here you can continue with your logic to generate TokenValues
    .....
    .....

    public void LoadXML(string path) 
    {
       var xElem2 = XElement.Load(path);
       var demail = xElem2.Descendants("email")
    					  .ToDictionary(
    							x => (string)x.Attribute("h1")
                                , x => Tuple.Create(
    										(string)x.Attribute("body") 
    										, x.Attribute("ids").Value
    														    .Split(',')
    														    .ToList()
    								    )
    						);
    }

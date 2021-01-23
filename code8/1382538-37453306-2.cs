	XDocument doc = XDocument.Load(filename);		
	var fmatch = doc.Root.Elements("DateTime")
 			              .FirstOrDefault(x=>x.Attribute("date").Value == attribute2.Value);
    if(fmatch!= null)
    {
        fmatch.Add(new XElement("child", "value")); // use details you would like to add as an element. 
    }
    // add attribute in element use below
            if (fmatch != null)
            {
                fmatch.Add( new XElement("Time", new XAttribute("time", DateTime.Now.ToString("hh:mm:ss tt")),"Test append in same date"));  
                doc.Save(@"E:\testdoc.xml");
            }

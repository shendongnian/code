    XDocument xmldata = XDocument.Load(xmlFile);
    XElement node = xmldata.Element("pair");
    if (node.Attribute("name").Value.Contains("cf_item"))
    {
           IEnumerable<XElement> nextElmts = node.Elements("pair");
           if (nextElmts.ElementAt(0).Attribute("name").Value.Contains("cf_id"))
           {
               if ((Convert.ToInt32(nextElmts.ElementAt(0).Value) == 34))
               {
                    if (Convert.ToInt32(nextElmts.ElementAt(1).Value) == 0)
                    {
                         //do what you want here
                         Console.WriteLine("it's 0");
                    }
               }
           }
    }

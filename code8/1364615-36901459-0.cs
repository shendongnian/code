    XElement testid = xliff.Descendants()
                           .Elements(xmlns + "trans-unit")
                           .Elements(xmlns + "seg-source")
                           .Elements(xmlns + "mrk")
                           .Where(e => e.Attribute("mtype").Value == "seg" && e.Attribute("mid").Value == SegId).FirstOrDefault();
    if (testid.Parent.Parent.PreviousNode.ToString().IndexOf("<target>") > 0)
    {
        return null;
    }
    else
    {
        var strid = xliff.Descendants()
                         .Select(e => testid.Parent.Parent.PreviousNode as XElement)
                         .Elements(xmlns + "source")
                         .Elements(xmlns + "x")
                         .LastOrDefault()
                         .Attribute("id")
                         .Value.ToString();
         return strid;
     }

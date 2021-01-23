    string val= "first";
    XmlDocument doc = new XmlDocument();
    doc.Load(Server.MapPath("./Xml/YourXML.xml"));
    string text = string.Empty;
    XmlNodeList xnl = doc.SelectNodes("/root/groups ");
    foreach (XmlNode node in xnl)
    {
        text = node.Attributes["name"].InnerText;
        if (text == val)
        {
             XmlNodeList xnl = doc.SelectNodes(string.Format("/root/groups [@name='{0}']/element", val));
            foreach (XmlNode node2 in xnl )
            {
                text = text + "<br>" + node2["id"].InnerText;
                text = text + "<br>" + node2["group"].InnerText;
            }
        }
        Response.Write(text);
    }

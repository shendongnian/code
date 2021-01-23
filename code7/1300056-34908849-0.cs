    public static void InsetXML(string user, string date, string content, string Xmlfile)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("news");
        xmlDoc.AppendChild(rootNode);
        XmlNode parent = xmlDoc.CreateElement("report");
        rootNode.AppendChild(parent);
        XmlNode child1 = xmlDoc.CreateElement("user");
        child1.InnerText = user;
        parent.AppendChild(child1);
        XmlNode child2 = xmlDoc.CreateElement("date");
        child2.InnerText = date;
        parent.AppendChild(child2);
        XmlNode child3 = xmlDoc.CreateElement("content");
        child3.InnerText = content;
        parent.AppendChild(child3);
    
        FileStream fsxml = new FileStream(Xmlfile, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
        xmlDoc.Save(fsxml);
        fsxml.Close();
    }

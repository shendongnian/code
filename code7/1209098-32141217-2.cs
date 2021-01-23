    string xml = AppDomain.CurrentDomain.BaseDirectory + "/WebData.xml";
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(xml);
    XmlNode t = xmlDoc.SelectSingleNode("/Data/PageInfo[ID='0']");
    t.ParentNode.RemoveChild(t);
    xmlDoc.Save(xml);

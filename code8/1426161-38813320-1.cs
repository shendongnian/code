    XmlDocument doc = new XmlDocument();
    doc.LoadXml(yourXml);
    XmlNodeList elements = doc.SelectNodes("//Element/Name");
    string name1 = elements[0].InnerText;
    string name2 = elements[1].InnerText;

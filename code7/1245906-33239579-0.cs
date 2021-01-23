    XmlDocument xml = new XmlDocument();
    xml.LoadXml(myXmlString); //myXmlString is the xml file in string //copying xml to string: string myXmlString = xmldoc.OuterXml.ToString();
    XmlNodeList xnList = xml.SelectNodes("/responset[@*]/Response");
    foreach (XmlNode xn in xnList)
    {
    XmlNode response = xn.SelectSingleNode("Response");
    if (response != null)
    {
    string rc = response["ReturnCode"].InnerText;
    string msg = example["Message"].InnerText;
    string data = example["Data"].InnerText;
    }
    } 

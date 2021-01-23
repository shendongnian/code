    XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyXMLData));
    XmlSerializerNamespaces ns1 = new XmlSerializerNamespaces();
    ns1.Add("", "http://www.mydata.org");
    Encoding encoding = Encoding.GetEncoding("UTF-8");
    using (StreamWriter sw = new StreamWriter(fileName, false, encoding))
    {
        xmlSerializer.Serialize(sw, myXMLData, ns1);
    }

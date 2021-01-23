    XmlDocument xml = new XmlDocument();
    xml.LoadXml(myXmlString);
    XmlNodeList names = xml.GetElementsByTagName("Names");
    for (int i = 0; i < names.Count; i++){
      string firstName = names.Item["FirstName"].InnerText;
      string lastName = names.Item["LastName"].InnerText;
      Console.WriteLine("Name: {0} {1}", firstName, lastName);
    }

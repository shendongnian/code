    private static void PrintOutNodesRecursive(XmlElement xmlElement, string currentStack)
    {
        foreach (XmlAttribute xmlAttribute in xmlElement.Attributes)
        {
            Console.WriteLine("{0}.{1} = {2}", currentStack, xmlAttribute.Name, xmlAttribute.Value);
        }
        foreach (XmlNode xmlNode in xmlElement.ChildNodes)
        {
            XmlElement xmlChildElement = xmlNode as XmlElement;
            XmlText xmlText = xmlNode as XmlText;
            if (xmlText != null)
            {
                Console.WriteLine("{0} = {1}", currentStack, xmlText.Value);
            }
            if (xmlChildElement != null)
            {
                PrintOutNodesRecursive(xmlChildElement, currentStack + "." + xmlChildElement.Name);
            }
        }
    }
    
    static void Main(string[] args)
    {
        string xmlContent = @"<bookstore>
          <book category=""COOKING"">
            <title lang=""en"">Everyday Italian</title>
            <author>Giada De Laurentiis</author>
            <year>2005</year>
            <price curr=""$"">30.00</price>
          </book>
        </bookstore>";
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlContent);
        PrintOutNodesRecursive(xmlDocument.DocumentElement, xmlDocument.DocumentElement.Name);
        
    }

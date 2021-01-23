    static void Main(string[] args)
    {
        string xmlSrc = @"<bookstore><book category=""COOKING""><title lang=""en"">Everyday Italian</title><author>Giada De Laurentiis</author><year>2005</year><price curr=""$"">30.00</price></book></bookstore>";
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlSrc);
        StringBuilder sbOut = new StringBuilder();
        sbOut.AppendLine("Nodes\tValues");
        sbOut.Append(XmlToText(xDoc.DocumentElement));
        Console.WriteLine(sbOut.ToString());
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
    static StringBuilder XmlToText(XmlElement node, string generationPath = "")
    {
        StringBuilder sbRet = new StringBuilder();
        generationPath += (String.IsNullOrEmpty(generationPath) ? "" : ".") + node.Name;
            
        foreach( XmlAttribute attr in node.Attributes)
        {
            sbRet.AppendLine(String.Format("{0}.{1}\t{2}", generationPath, attr.Name, attr.Value));
        }
        foreach( XmlNode child in node.ChildNodes)
        {
            if( child.NodeType == XmlNodeType.Element)
            {
                sbRet.Append(XmlToText(child as XmlElement, generationPath));
            }
            else if ( child.NodeType == XmlNodeType.Text)
            {
                sbRet.AppendLine(String.Format("{0}\t{1}", generationPath, child.InnerText));
            }
        }
        return sbRet;
    }

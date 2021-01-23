    XmlTextReader xReader = new XmlTextReader("../../Products.xml");
            xReader.WhitespaceHandling = WhitespaceHandling.None;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xReader);
            Console.WriteLine("Please enter product...");
            string product = Console.ReadLine();
            XmlNodeList xNodeList = xDoc.DocumentElement.SelectNodes("//Products/Product");
            foreach (XmlNode xNode in xNodeList)
            {
                if (xNode.NodeType == XmlNodeType.Element)
                {
                   // Console.WriteLine(xNode.NodeType.ToString() + " : " + xNode.Name + " =" + xNode.FirstChild.InnerText);
                    if (xNode.FirstChild.InnerText == product)
                    {
                        string name = xNode.FirstChild.InnerText;
                        string price = xNode.FirstChild.NextSibling.InnerText;
                        Console.WriteLine("Name: " + name + "... Price: R" + price);
                    }
                    else
                    {
                        Console.WriteLine("No Price");
                    }
                }
            }
            Console.ReadLine();
    

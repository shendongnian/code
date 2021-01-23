            XmlDocument doc = new XmlDocument();
            doc.LoadXml("[YUOR XML PATH]");
            XmlNode node1 = doc.SelectSingleNode("ERROR");
            XmlNode node2 = doc.SelectSingleNode("Error");
            XmlNode node3 = doc.SelectSingleNode("//ERROR");
            XmlNode node4 = doc.SelectSingleNode("//Error");
            XmlNode node5 = doc.SelectSingleNode("SMS/ERROR");
            XmlNode node6 = doc.SelectSingleNode("SMS/Error");
            if (node1 == null)
            { Console.WriteLine("Node 1 is null"); }
            if (node2 == null)
            { Console.WriteLine("Node 2 is null"); }
            if (node3 == null)
            { Console.WriteLine("Node 3 is null"); }
            if (node4 == null)
            { Console.WriteLine("Node 4 is null"); }
            if (node5 == null)
            { Console.WriteLine("Node 5 is null"); }
            if (node6 == null)
            { Console.WriteLine("Node 6 is null"); }

     public static void TraverseXml(XmlNodeList nodeList)
        {
            foreach (XmlNode node1 in nodeList)
            {
                if (node1.Attributes!=null && node1.Attributes["match"] != null)
                {
                    Console.WriteLine("first match value:" + node1.Attributes["match"].Value);
                }
                TraverseXml(node1.ChildNodes);
            }
            Console.ReadLine();
        }

    public static List<XmlNode> TraverseXml(XmlNodeList nodeList, int counter = 1)
        {
            List<XmlNode> matchNode = new List<XmlNode>();
           
            foreach (XmlNode node1 in nodeList)
            {
                if (node1.Attributes != null && node1.Attributes["match"] != null)
                {
                    matchNode.Add(node1.Attributes["match"]);
                    Console.WriteLine(counter + " match value:" + node1.Attributes["match"].Value);
                    counter++;
                }
                TraverseXml(node1.ChildNodes, counter);
            }
            Console.ReadLine();
            return matchNode;
        }

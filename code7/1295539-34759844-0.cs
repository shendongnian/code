    public static void TraverseXml(XmlNodeList nodeList, int counter = 1)
        {
            foreach (XmlNode node1 in nodeList)
            {
                if (node1.Attributes != null && node1.Attributes["match"] != null)
                {
                    Console.WriteLine(counter + " match value:" + node1.Attributes["match"].Value);
                    counter++;
                }
                TraverseXml(node1.ChildNodes, counter);
            }
            Console.ReadLine();
        }

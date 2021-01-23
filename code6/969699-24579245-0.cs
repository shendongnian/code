        string[] filePaths = Directory.GetFiles(@"C:\Users\r626890\Documents\BoxTesting\",      "*.xml");
        foreach (string file in filePaths)
        {
            Console.WriteLine("'{0}'",file);
            Console.WriteLine();
            XmlDocument doc = new XmlDocument();
            //string file = filePaths[0].ToString();
            XmlNodeList xmlnode;
            doc.Load(file);
            XmlNodeList indexValue = doc.GetElementsByTagName("Index");
            for (int i = 0; i < indexValue.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Description: {0} ",             indexValue[i].ChildNodes.Item(0).InnerXml);
                Console.WriteLine("Value:       {0} ", indexValue[i].ChildNodes.Item(1).InnerXml);
            //  Console.WriteLine("{0}",i);
            }
            xmlnode = doc.GetElementsByTagName("FileName");
            for (int i = 0; i < xmlnode.Count; i++)
            {
                // Console.WriteLine("URI: {0} ", elemList[i].InnerXml.Split('_')[0]);
                Console.WriteLine();
                Console.WriteLine("Type:        {0} ", xmlnode[i].InnerXml.Split('_')[1]);
                Console.WriteLine();
                Console.WriteLine("File Name:   {0} ", xmlnode[i].InnerXml);
                                 Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("(Total # of files: {0})", ++i);
            }
        }
        Console.ReadLine();

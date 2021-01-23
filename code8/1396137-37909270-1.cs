            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\temp\image.xml");
            
            XmlNodeList elemList = doc.GetElementsByTagName("value");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerXml);
            }
            

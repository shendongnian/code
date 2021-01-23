            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\XMLFile.xml");
            XmlNodeList elemPrice = doc.SelectNodes("/catalog/cd/price");
            for (int i = 0; i < elemPrice.Count; i++)
            {
                Console.WriteLine(elemPrice[i].Name);
                Console.WriteLine(elemPrice[i].InnerText);
            }

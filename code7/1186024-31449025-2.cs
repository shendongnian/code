            XmlDocument doc = new XmlDocument();
            // PATH TO YOUR DOCUMENT
            doc.Load("daco.xml");
            // Select LIST ALL ELEMENTS SmallImage,MediumImage,LargeImage
            XmlNodeList listOfAllImageElements = doc.SelectNodes("/Items/*");
            foreach (XmlNode imageElement in listOfAllImageElements)
            {
                // Select URL ELEMENT
                XmlNode urlElement= node.SelectSingleNode("URL");
                System.Console.WriteLine(urlElement.InnerText);
            }
            Console.ReadLine();

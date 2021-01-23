       private string parseResponseByXML(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList xnList = xmlDoc.SelectNodes("/SessionInfo");
            string node ="";
            if (xnList != null && xnList.Count > 0)
            {
                foreach (XmlNode xn in xnList)
                {
                    node= xn["SessionID"].InnerText;
                }
            }
            return node;
        }

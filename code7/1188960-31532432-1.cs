          public List<string> GetAccountsAsXmlList(string filePath)
          {
            XmlDocument x = new XmlDocument();
     
            x.Load(filePath);
            List<string> result = new List<string>();
            XmlNode currentNode;
            foreach (var accountNode in x.LastChild.FirstChild.ChildNodes)
            {
                currentNode = accountNode  as XmlNode;
                result.Add(currentNode.InnerXml);
            }
              return result;
          }

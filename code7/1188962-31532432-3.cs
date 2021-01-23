       public List<Account> GetAccountsAsXmlList(string filePath)
       {
         XmlDocument x = new XmlDocument();
         x.Load(filePath);
         List<Account> result = new List<Account>();
         XmlNode currentNode;
         foreach (var accountNode in x.LastChild.FirstChild.ChildNodes)
         {
             currentNode = accountNode as XmlNode;
             result.Add(new Account
             {
                 accountXml = currentNode.InnerXml,
                 Id = currentNode.Attributes["id"].Value,
                 Special_id = currentNode.Attributes["special_id"].Value,
             });
         }
          return result;
     }

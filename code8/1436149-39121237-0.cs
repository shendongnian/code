    XmlDocument nodeDoc = new XmlDocument();
    linksDoc.Load(Server.MapPath("App_Data/Node.xml"));
    foreach (ListItem li in lb1.Items)
    {
      string itemId = li.Value;
    
      XmlNode node = doc.SelectSingleNode(string.Format("/root/node[@id = '{0}']", itemId));
      if (node != null)
      {
        node.ParentNode.AppendChild(node);
      }
    }

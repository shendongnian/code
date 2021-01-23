    foreach (XmlNode node in elementNodes)
      {
        id = node.SelectSingleNode("dataSourceObjectId").InnerXml; //I'm not sure if this will solve the problem.
        if (!elements.ContainsKey(id))
        {
          name = node.SelectSingleNode("name").InnerText;
          elements.Add(id, name);
        }
      }

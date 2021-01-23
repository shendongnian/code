      var nodeList = new List<Node>();
      var allNodes = new List<Node>();
      Node rootNode = null;
      Node parentNode = null;
      Node currentNode = null;
      foreach (var htmlNode in body.ChildNodes)
      {
        int? level;
        if (IsHeading(htmlNode.Name, out level) && level.HasValue)
        {
          currentNode = new Node();
          currentNode.Title = htmlNode.InnerText;
          currentNode.Html = htmlNode.OuterHtml;
          currentNode.Level = level.Value;
          allNodes.Add(currentNode);
          if (rootNode == null || currentNode.Level == 1)
          {
            rootNode = currentNode;
            nodeList.Add(rootNode);
            parentNode = null;
          }
          if (parentNode != null)
          {
            if (parentNode.Level >= currentNode.Level)
            {
              parentNode = allNodes.Last(n => n.Level < currentNode.Level);
            }
            parentNode.SubNodes.Add(currentNode);
          }
          parentNode = currentNode;
          continue;
        }
        if (rootNode == null)
        {
          continue;
        }
        currentNode.Html += htmlNode.OuterHtml;
      }

    foreach (HtmlNode n in doc.DocumentNode.Descendants())
    {
            if (n.Attributes.Count != 0)
            {
                  nodes.Add("//"+n.Name + "[@" + n.Attributes[0].Name+"='"+n.Attributes[0].Value+"']");
             }
             else
             {
                   nodes.Add(n.Name);
              }
      }
      List<string> ComboItems = nodes.Distinct().ToList();
      _comboFilterNode.ItemsSource = ComboItems;

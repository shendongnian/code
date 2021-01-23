    var XmlData = XDocument.Load("PathToFile");
    List<string> XmlItems = new List<string>();
    var XQuery = from m in XmlData.Root.Elements()
                 where m.Attribute("Category").Value.ToString().Equals("TheCategory")
                 select (m.Attribute("TheAttribute").Value).Distinct().ToString();
    XmlItems.AddRange(XQuery);
    foreach (var item in XmlItems)
    {
        ComboBoxTeams.Items.Add(item);
    }

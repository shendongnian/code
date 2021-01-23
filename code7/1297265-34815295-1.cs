    var XmlData = XDocument.Load("PathToFile");
    var XmlItems = (from m in XmlData.Root.Elements()
                     where m.Attribute("Category").Value.ToString().Equals("TheCategory")
                     select (m.Attribute("TheAttribute").Value.ToString())).Distinct();
    foreach (var item in XmlItems)
    {
        ComboBoxTeams.Items.Add(item);
    }

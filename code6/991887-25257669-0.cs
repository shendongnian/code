    List<string> items = new List<string>();
    foreach (XmlNode y in x.ParentNode.SelectNodes("Entity"))
    {
        items.Add(y.Value);
    }
    table1.Controls.Add(new ComboBox() { Name = attributes[x].Name, SelectedText = attributes[x].Value,Items = items, AutoSize = true });

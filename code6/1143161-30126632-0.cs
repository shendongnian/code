        string xml = 
    @"<?xml version=""1.0"" encoding=""utf-8"" ?>
    <personas>
      <persona>
        <nombre>Pablo el primero</nombre>
        <ocupacion>Programador Cliente-Servidor</ocupacion>
      </persona>
      <persona>
        <nombre>Pablo el segundo</nombre>
        <ocupacion>Programador Web</ocupacion>
      </persona>
    </personas>";
            XDocument doc = XDocument.Parse(xml);
            List<ListViewItem> ItemList = new List<ListViewItem>();
            foreach (XElement elem in doc.Elements())
            {
                AddNewItemToList(ItemList, elem);
            }
            listView1.Items.AddRange(ItemList.ToArray());
...
    private void AddNewItemToList(List<ListViewItem> ItemList, XElement elem)
        {
            string attributes = "";
            if (elem.HasAttributes)
            {
                foreach (XAttribute attr in elem.Attributes())
                {
                    attributes += " " + attr.Name + "=\"" + attr.Value + "\"";
                }
            }
            if (elem.HasElements)
            {
                ItemList.Add(new ListViewItem("<" + elem.Name + attributes + ">"));
                foreach (XElement childElem in elem.Elements())
                {
                    AddNewItemToList(ItemList, childElem);
                }
                ItemList.Add(new ListViewItem("</" + elem.Name + ">"));
            }
            else
            {
                ItemList.Add(new ListViewItem("<" + elem.Name + attributes + ">" + elem.Value + "</" + elem.Name + ">"));
            }
        }

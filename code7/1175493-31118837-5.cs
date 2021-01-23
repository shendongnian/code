    var items = solutions.Descendants("Solution")
        .Select(x => new MyItem
        {
            ID = (string)x.Element("ID"),
            Properties = x.Elements("Property").Select(p => new
            {
                Name = (string)p.Element("Name"),
                Value = (string)p.Element("Value"),
                idx = (i < 11 ? i++ : i = 0)
            })
            .Where(y => indexesToChoose.Contains(y.idx))
            .OrderBy(z => indexesToChoose.FindIndex(p => p == z.idx))
            .Select(z => new Tuple<string, string>(z.Name, z.Value))
            .ToList()
        }).ToArray();
    
    comboBox1.DisplayMember = "Text";
    comboBox1.ValueMember = "ID";
    comboBox1.Items.AddRange(items);

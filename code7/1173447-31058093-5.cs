    var items = solutions
       .Select(s => new {
           ID = s.ID,
           Text = string.Format("{0}. {1}", s.ID,
               string.Join(", ", s.Properties
                                  .Select(p => string.Format("{0} = {1}",
                                                             p.Name,
                                                             p.Value ?? "(nothing/0)"))))
       }).ToArray();
    comboBox.DisplayMember = "Text";
    comboBox.ValueMember = "ID";
    comboBox.Items.AddRange(items);

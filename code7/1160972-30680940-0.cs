    for (int i = 0; i < query.Count(); i++)
    {
        ComboboxItem item = new ComboboxItem();
        item.Text = query[i].gaptitle1.ToString();
        item.Value = query[i].id.ToString();
    
        comboBox2.Items.Add(item);
     }

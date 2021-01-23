    ComboboxItem item = new ComboboxItem();
    var result = videoCatagories.Execute();
    for (int i = 0; i < result.Items.Count; i++)
    {
        if(!comboBox1.Items.Contains(item))
        {
                item.Text = result.Items[i].Snippet.Title;
                item.Value = result.Items[i].Id;
                comboBox1.Items.Add(item);
        }
    }

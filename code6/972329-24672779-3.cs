    private void SetListView(string input)
    {
        var values = input.Split(' ');
        for (var i = 0; i < values.Length; i++)
            ColumnsListView.Columns.Add("Column" + (i + 1));
            
        var item = new ListViewItem(values[0]);
        item.SubItems.AddRange(values.Skip(1).ToArray());
        ColumnsListView.Items.Add(item);
    }
    

    private void SetListView(string input)
    {
        var values = input.Split(' ');
        var item = new ListViewItem(values[0]);
            
        item.SubItems.AddRange(values.Skip(1).ToArray());
        ColumnsListView.Columns.Add("Column1");
            
        for (var i = 1; i < values.Length; i++)
            ColumnsListView.Columns.Add("Column" + (i+1));
        ColumnsListView.Items.Add(item);
    }
    

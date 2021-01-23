    private void SetListView(string input)
    {
        var values = input.Split(' ');
        ColumnsListView.Columns.Add("Column1");
        var item = new ListViewItem(values[0]);
        
        for (var i = 1; i < values.Length; i++)
        {
            ColumnsListView.Columns.Add("Column" + (i+1));
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = values[i] });
        }
        ColumnsListView.Items.Add(item);
    }

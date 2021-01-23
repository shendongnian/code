    private void SetDataGridView(string input)
    {
        var values = input.Split(' ');
            
        for (var i = 0; i < values.Length; i++)
            ColumnsDataGridView.Columns.Add("Column" + (i + 1), "Column" + (i + 1));
        ColumnsDataGridView.Rows.Add(values);
    }

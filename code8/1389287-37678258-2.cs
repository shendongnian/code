    DataGridView1.CellParsing += ColorCellParsing;
    private void ColorCellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        var grid = (DataGridView)sender;
        var column = grid.Columns[e.ColumnIndex] as DataGridViewComboBoxColumn;
        if (column == null || column.Name != "Color")
            return;
        foreach (ComboboxColorItem item in column.Items)
        {
            if (item.Name == (string) e.Value)
            {
                e.Value = item;
                e.ParsingApplied = true;
                break;
            }    
        }
    }

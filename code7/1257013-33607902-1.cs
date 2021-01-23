    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        DataGridItem item = (DataGridItem)txt.NamingContainer;
        DataGrid grid = (DataGrid)item.NamingContainer;
        DataControlField column = grid.Columns.Cast<DataControlField>()
            .Select((c, Index) => new { Column = c, Index })
            .Where(x => item.Cells[x.Index].GetControlsRecursively().Contains(txt))
            .Select(x => x.Column)
            .FirstOrDefault();
        if (column != null)
        {
            string headerText = column.HeaderText;
        }
    }

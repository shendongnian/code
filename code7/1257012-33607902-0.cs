    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        GridView grid = (GridView)row.NamingContainer;
        DataControlField column = grid.Columns.Cast<DataControlField>()
            .Select((c, Index) => new { Column = c, Index })
            .Where(x => row.Cells[x.Index].GetControlsRecursively().Contains(txt))
            .Select(x => x.Column)
            .FirstOrDefault();
        if (column != null)
        {
            string headerText = column.HeaderText;
        }
    }

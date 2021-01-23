    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null)
            return;
        if (e.RowIndex < 0)
            return;
        // only for 2nd column
        if (e.ColumnIndex != 1)
            return;
        var txt = e.Value.ToString();
        if (txt.Length > 4608)
        {
            e.Value = txt.Substring(0, 4608);
            e.FormattingApplied = true;
        }
    }

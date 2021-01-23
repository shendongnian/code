    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
        {
            if (e.Value != null)
            {
                e.Value = Encoding.UTF8.GetString((byte[]) e.Value);
                e.FormattingApplied = true;
            }
            else
                e.FormattingApplied = false;
        }
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 1 && e.Value != null)
        {
            e.Value = new String('*', e.Value.ToString().Length);
        }
    }

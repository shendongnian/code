    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex == this.dataGridView1.NewRowIndex)
            return;
        if (e.ColumnIndex == this.dataGridView1.Columns["LinkColumn"].Index)
        {
            e.Value = e.RowIndex + 1;
        }
    }

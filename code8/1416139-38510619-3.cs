    private void dataGridView1_CellContextMenuStripNeeded(object sender,
        DataGridViewCellContextMenuStripNeededEventArgs e)
    {
        if (e.RowIndex > -1 && e.ColumnIndex > -1)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            e.ContextMenuStrip = contextMenuStrip1;
        }
    }

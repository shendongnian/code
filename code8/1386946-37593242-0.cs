    public Action<string> DataSelectedCallback;
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (DataSelectedCallback != null)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataSelectedCallback(cell.Value)
        }
    }

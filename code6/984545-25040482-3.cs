    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        int a = e.ColumnIndex;
        int b = dataGridView1.Columns[dataGridViewCheckBoxColumn1.Name].Index;
        int c = dataGridViewCheckBoxColumn1.Index;
        if (e.RowIndex >= 0 && e.ColumnIndex.Equals(dataGridView1.Columns[dataGridViewCheckBoxColumn1.Name].Index))
            dataGridView1.Rows[e.RowIndex].Cells[dataGridViewTextBoxColumn2.Index].Value = true;
    }

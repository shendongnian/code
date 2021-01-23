    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == -1)
            MessageBox.Show(e.RowIndex.ToString());
    }
    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex == -1)
            MessageBox.Show(e.RowIndex.ToString());
    }
    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex == -1)
            MessageBox.Show(e.RowIndex.ToString());
    }

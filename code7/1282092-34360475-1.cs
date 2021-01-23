    dataGridView1.RowsAdded += RowsAdded;
    dataGridView1.RowsRemoved += RowsRemoved;
    private void RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        txtTotalItem.Text = dataGridView1.Rows.Count;
    }
    private void RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        txtTotalItem.Text = dataGridView1.Rows.Count;
    }

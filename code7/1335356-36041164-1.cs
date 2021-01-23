    this.dataGridView1.CellContentClick += DataGridView1_CellContentClick;
    this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
        {
            System.Diagnostics.Process.Start(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string);
        }
    }
    private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow row in this.dataGridView1.Rows)
        {
            row.Cells["Module"] = new DataGridViewLinkCell();
        }
    }

    private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewColumn col in this.dataGridView1.Columns)
        {
            col.Visible = false;
        }
        this.dataGridView1.RowHeadersVisible = false;
        this.dataGridView1.ScrollBars = ScrollBars.None;
    }

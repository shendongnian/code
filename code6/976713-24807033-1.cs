    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex.Equals(dataGridView1.Columns["Amount"].Index))
        {
            UpdateTotal();
        }
    }
    private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
    {
        UpdateTotal();
    }
    private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
    {
        UpdateTotal();
    }
    private void UpdateTotal()
    {
        textBox1.Text = (dataGridView1.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells["Amount"].Value))).ToString();
    }

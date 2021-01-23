    private void AddRow_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows.Add();
    }
    
    private void ChangeCheck_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            if (row.Cells[0].ValueType == typeof(bool))
            {
                if (row.Cells[0].Value == null)
                    row.Cells[0].Value = true;
                else
                    row.Cells[0].Value = !(bool)row.Cells[0].Value;
            }
        }
    }

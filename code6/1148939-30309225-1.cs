    private void button1_Click(object sender, EventArgs e)
    {
        StringBuilder ln = new StringBuilder();
        // dataGridView1.ClearSelection(); makes no sense!?
        if (dataGridView1.SelectedRows.Count <= 0) 
            MessageBox.Show("No row is selected!");
        else
        {
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[i];
                if (((bool?)row.Cells[0].Value) == true)
                {
                    ln.Append(row.Cells[1].FormattedValue);
                }
            }
            MessageBox.Show("Row Content -" + ln);
        }
    }

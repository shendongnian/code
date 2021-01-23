    private void button3_Click(object sender, EventArgs e)
    {
        StringBuilder ln = new StringBuilder();
        // dataGridView1.ClearSelection(); makes no sense!?
        if (dataGridView1.SelectedRows.Count <= 0) 
            MessageBox.Show("No row is selected!");
        else
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (((bool)row.Cells[0].Value) == true)
                {
                    ln.Append(row.Cells[1].FormattedValue.ToString());
                }
            }
            MessageBox.Show("Row Content -" + ln);
        }
    }

    dataGridView1.Columns[0].ReadOnly = true;
    dataGridView1.AllowUserToAddRows = false;
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        int x;
        if (int.TryParse(row.Cells[1].Value.ToString(), out x))
        {
            MessageBox.Show("Valid");
        }
    }

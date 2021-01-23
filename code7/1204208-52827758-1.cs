    private void btnRowAdd_Click(object sender, EventArgs e)
    {
        String[] row = { "", "", "", "", "", "", "" };
        dataGridView1.Rows.Add(row);
        dataGridView1.AllowUserToAddRows = false;
    }

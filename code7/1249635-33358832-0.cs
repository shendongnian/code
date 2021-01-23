    void DataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        DataGridView temp = (DataGridView)sender;
        if (temp.CurrentRow == null)
            return; //Or clear your TextBoxes
        txtFullName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        txtUsername.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        txtPassword.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
    }

    if (comboBox1.Text == "Search")
    {
        bool found = false;
        foreach (DataGridViewRow dgvr in dataGridView_produkty.Rows)
        {
            if (dgvr.Cells[0].Value != null)
            {
                if (dgvr.Cells[0].Value.ToString().Contains(textBox_szukaj.Text))
                {
                    dgvr.Visible = true;
                    found = true;
                    continue;                                             
                }
                dgvr.Visible = false;
            }
        }
        if(!found) MessageBox.Show("Item not found");
    }

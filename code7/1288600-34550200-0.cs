    if (comboBox1.Text == "Search")
    {
        foreach (DataGridViewRow dgvr in dataGridView_produkty.Rows)
        {
            if (dgvr.Cells[0].Value != null)
            {
                if (dgvr.Cells[0].Value.ToString().Contains(textBox_szukaj.Text))
                {
                    dgvr.Visible = true;
                    continue;                                             
                }
                dgvr.Visible = false;
    
                MessageBox.Show("Item not found");
            }
        }
    }

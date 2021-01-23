    if (comboBox1.Text == "Search")
    {
        bool itemFound = false;
        foreach (DataGridViewRow dgvr in dataGridView_produkty.Rows)
        {
            if (dgvr.Cells[0].Value != null)
            {
                if (dgvr.Cells[0].Value.ToString().Contains(textBox_szukaj.Text))
                {
                    dgvr.Visible = true;
                    itemFound = true;
                    continue;                                             
                }
                dgvr.Visible = false;
            }
        }
        if (!itemFound)
        {
            MessageBox.Show("Item not found");
        }
    }
    

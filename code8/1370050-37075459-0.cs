    string searchValue = textBox1.Text;
    
        dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        try
        {
            foreach (DataGridViewRow row in dgvProjects.Rows)
            {
                if (row.Cells[2].Value.ToString().Equals(searchValue))
                {
                    row.Selected = true;
                    break;
                }
            }
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }

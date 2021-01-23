        private void searchbutton_Click(object sender, EventArgs e)
        {
        string searchValue = searchtextBox.Text;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        try
        {
            bool valueResult = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                    {
                        int rowIndex = row.Index;
                        dataGridView1.Rows[rowIndex].Selected = true;
                        valueResult = true;
                        break;
                    }
                }
            }
            if (!valueResult)
            {
                MessageBox.Show("Unable to find " + searchtextBox.Text, "Not Found");
                return;
            }
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

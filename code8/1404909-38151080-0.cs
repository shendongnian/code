    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("Cannot Empty!");
                e.Cancel = true;
            }
            else if (!isNumeric(e.FormattedValue.ToString())
            {
                MessageBox.Show("Only can input number!");
                e.Cancel = true;
            }
    
        }

    private void dataGridView1_CellValidating(object sender,
    DataGridViewCellValidatingEventArgs e)
    {
        string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
        // Abort validation if cell is not in the CompanyName column. 
        if (!headerText.Equals("CompanyName")) return;
        // Confirm that the cell is not empty. 
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                "Company Name must not be empty";
                 e.Cancel = true; 
    }

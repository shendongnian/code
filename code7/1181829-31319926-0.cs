    private void DataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        // get here the row values to be used to determine the ComboBox content
        // Adapt the 2 following lines
        int    col1Value = (int   )dataGridView1.Rows[e.RowIndex].Cells["col1Name"].Value ;
        string col2Value = (string)dataGridView1.Rows[e.RowIndex].Cells["col2Name"].Value ;
        List<string> PoleValues = new List<String>() ;
        // Here, your code to add to PoleValues the ComboBox values from colXValues
        ...  
        DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)DatagridView2.Columns["RefDataGridViewTextBoxColumn"] ;
        cb.Items.clear() ;
        cb.Items.AddRange(PoleValues) ;
    }

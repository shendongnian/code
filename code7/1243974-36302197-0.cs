    private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        var senderGrid = (DataGridView)sender;
        foreach (DataGridViewRow row in senderGrid.Rows)
        {
            // Determine the bound data object for the current row
            var currentRowObj = row.DataBoundItem;
            // Access the data in a particular cell on this row
            var cellToTotal = row.Cells["Column1"];
            
            etc
        }
    }

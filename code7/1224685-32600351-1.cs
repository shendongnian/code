    void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //if click is on new row or header row
        if( e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            return;
        
        //Handle Button Click
        //dataGridView1.Columns[YourColumnIndex] works too
        if( e.ColumnIndex  == dataGridView1.Columns["YourColumnName"].Index)
        {
            //Do the stuff for button click
            //for example DownloadFile(url, dataGridView1.Rows[e.RowIndex].Cells["YourFileNameColumn"].Value.ToString(), username, password, destinationPath)
            MessageBox.Show("Button Clicked");
        }
    }

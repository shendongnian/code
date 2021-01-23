    void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //if click is on new row or header row
        if( e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            return;
        
        //Handle First Button Click
        if( e.ColumnIndex  == dataGridView1.Columns["Your First Button"].Index)
        {
            //Do the stuff for first button click
            MessageBox.Show("First Button Clicked");
        }
        //Handle Second Button Click
        if( e.ColumnIndex == dataGridView1.Columns["Your Second Button"].Index)
        {
            //Do the stuff for second button click
            MessageBox.Show("Seccond Button Clicked");
        }
    }

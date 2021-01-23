    void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //if click is on new row or header row
        if( e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            return;
    
        //Handle Button Column Click
        if( e.ColumnIndex  == dataGridView1.Columns["YourButtonColumnName"].Index)
        {
            //Do the stuff for first button click
        }
    }

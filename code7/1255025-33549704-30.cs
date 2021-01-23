    void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //if click is on new row or header row
        if( e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            return;
    
        //Check if click is on specific column 
        if( e.ColumnIndex  == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
        {
            //Put some logic here, for example to remove row from your binding list.
            //yourBindingList.RemoveAt(e.RowIndex);
            
            // Or
            // var data = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            // do something 
        }
    }

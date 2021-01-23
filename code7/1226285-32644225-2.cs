    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        //If this is header row or new row, do nothing
        if (e.RowIndex < 0 || e.RowIndex == this.dataGridView1.NewRowIndex)
            return;
        // If this is 4th column, Set the value to Edit
        //if (e.ColumnIndex=this.dataGridView1.Columns["YourEditColumnName"].Index)
        if(e.ColumnIndex==4)
        {
            e.Value = "Edit";
        }
        // If this is 5th column, Set the value to Delete
        //if(e.ColumnIndex=this.dataGridView1.Columns["YourDeleteColumnName"].Index)
        if(e.ColumnIndex==5)
        {
            e.Value = "Delete";
        }
    }

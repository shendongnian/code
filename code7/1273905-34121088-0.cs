    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        //Suppose 0 is the index of Name column and 1 is the index of Status Column
        //We check if the change is in a datagrid view row and in name column 
        //Then we change value of Status column.
        if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            this.dataGridView1.Rows[e.RowIndex].Cells[1].Value = "Modified";
    }

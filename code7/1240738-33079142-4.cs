    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if(e.ColumnIndex==1 && e.RowIndex>-1)
        {
            //Check if the event is for your column, for example column 1
            var column = (DataGridViewComboBoxColumn)this.dataGridView1.Columns[e.ColumnIndex];
            //use column.DataSource   
        }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        //We make DataGridCheckBoxColumn commit changes with single click
        //use index of logout column
        if(e.ColumnIndex == 4 && e.RowIndex>=0)
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //Check the value of cell
        if((bool)this.dataGridView1.CurrentCell.Value == true)
        {
            //Use index of TimeOut column
            this.dataGridView1.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
            
            //Set other columns values
        }
        else
        {
            //Use index of TimeOut column
            this.dataGridView1.Rows[e.RowIndex].Cells[3].Value = DBNull.Value;
            
            //Set other columns values
        }
    }

    void dataGridView1_EditingControlShowing(object sender, 
                                             DataGridViewEditingControlShowingEventArgs e)
    {
        //Suppose column at index 1 is for dependent combo
        if (this.dataGridView1.CurrentCell.ColumnIndex == 1)  
        {
            var c = (DataGridViewComboBoxEditingControl)e.Control;
            //Suppose column at index 0 is for master cell
            var value = this.dataGridView1
                            .Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
            if (value != null)
            {
                c.DataSource = LoadData((int)value); //Load a subset of data
            }
            else
            {
                c.DataSource = null;
            }
        }
    }

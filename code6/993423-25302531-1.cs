        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
                { //for getting cell value
                    string p;
                    var senderGrid = (DataGridView)sender;
        
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        //TODO - Button Clicked - Execute Code Here
                        p = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        comboProname.Text = p; 
                    }           
                    
                }
     private void buttonSave_Click(object sender, EventArgs e)
    {
     int selectedIndex = DataGridView1.CurrentCell.RowIndex;
    
        if (selectedIndex > -1)
        {
            DataGridView1.Rows.RemoveAt(selectedIndex);
            DataGridView1.Refresh();
        }
    }

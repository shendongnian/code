     private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1")
                {
    
                    DataGridViewCheckBoxCell checkCell =
                       (DataGridViewCheckBoxCell)dataGridView1.
                        Rows[e.RowIndex].Cells["Column1"];
                    if ((bool)checkCell.Value == true) {
                        int i = dataGridView1.CurrentRow.Index;
                        string col = dataGridView1.Rows[e.RowIndex].Cells["column2"].Value.ToString();
                    }
                    
                }
            }

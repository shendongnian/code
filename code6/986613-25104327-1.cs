    private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex != -1)
        {
            dataGridView1.EndEdit();
        }
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex != -1)
        {
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                if (!dc.Index.Equals(0))
                {
                    dc.ReadOnly =                                          
                        !(bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                            
            }
        }
    }

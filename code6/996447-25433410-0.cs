    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rptIdValue1 = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                foreach (DataGridViewRow r2 in dataGridView2.Rows)
                {
                    if ((int)r2.Cells[0].Value != rptIdValue1)
                        continue;
                    dataGridView2.Rows[r2.Index].Selected = true;
                    dataGridView2.CurrentCell = dataGridView2.Rows[r2.Index].Cells[0];
                    break;                           
                }
                foreach (DataGridViewRow r3 in dataGridView3.Rows)
                {
                    int dgv3Index = (int)dataGridView3.Rows[e.RowIndex].Cells[0].RowIndex;
                    if ((int)r3.Cells[0].Value != rptIdValue1) 
                        continue;
                    dataGridView3.Rows[r3.Index].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3.Rows[r3.Index].Cells[0];
                    break;                            
                }
            
        }

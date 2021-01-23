     private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            {
                bool oldVal = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
    
                DialogResult r = MessageBox.Show("Really?", "", MessageBoxButtons.OKCancel);
                if (r == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !oldVal;
                }
            }

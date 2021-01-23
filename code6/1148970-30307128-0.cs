    private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
     {
            int a, b;
            if (dataGridView1.Rows.Count > 0 && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    a = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    b = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    if (b > a)
                    {
                        MessageBox.Show("required quantity exceeds stock");
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                    //Or whatever you've planned for...
                }
                
            }
     }

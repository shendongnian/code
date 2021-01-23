    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {
                   int i = e.RowIndex;
                    DataGridViewRow row = dataGridView1.Rows[i];
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();    
                }

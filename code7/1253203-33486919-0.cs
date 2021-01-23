    string[,] invoice = new string[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        invoice[row.Index, col.Index] = dataGridView1.Rows[row.Index].Cells[col.Index].Value.ToString();
                    }
                }

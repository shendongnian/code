                int rowc = dataGridView1.Rows.Count - 1;
            for (int i = 0; i <= rowc; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "a1")
                {
                    for (int z = 0; z <= dataGridView1.ColumnCount - 1; z++)
                    {
                        dataGridView1.Rows[i].Cells[z].Style.ForeColor = Color.Black;
                    }
                }
                else if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "a2")
                {
                    for (int z = 0; z <= dataGridView1.ColumnCount - 1; z++)
                    {
                        dataGridView1.Rows[i].Cells[z].Style.ForeColor = Color.Blue;
                    }
                }
                else if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "a3")
                {
                    for (int z = 0; z <= dataGridView1.ColumnCount - 1; z++)
                    {
                        dataGridView1.Rows[i].Cells[z].Style.ForeColor = Color.Red;
                    }
                }
            }

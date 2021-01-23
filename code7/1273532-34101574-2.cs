        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count -1; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    if (i < dataGridView1.Rows.Count -1)
                    {
                        i--;
                    }
                    
                }
            }
        }

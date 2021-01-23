            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1[1, i].Value.ToString() == "F")
                {
                    intfemdelegates = intfemdelegates + 1;
                    dataGridView1[1, i].Style.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
            lblcount.Text = intfemdelegates.ToString();

                int j = 0;
                int countRows = dataGridView1.Rows.Count;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i]
                                          .Cells[0].Value) == true)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                    i = i - 1;
                    j = j + 1;
                    if (j == countRows)
                    {
                        break;
                    }
                }

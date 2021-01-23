    int result = 0;
            if (int.TryParse(txtLessThanFollowersCount.Text.Trim(), out result))
            {
                for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
                {
                    int parse;
                    if (int.TryParse(txtLessThanFollowersCount.Text.Trim(), out parse))
                    {
                        if (Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) < parse)
                        {
                            dataGridView1.Invoke(new Action(() => dataGridView1.Rows.RemoveAt(i)));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error in the follower count selection", "Error");
            }

    foreach (DataGridViewRow itemRow in dg2.Rows)
                    {
                        if (bool.Parse(Convert.Tostring(itemRow.Cells[14].Value)))
                        {
            da = new SqlDataAdapter("DELETE FROM allowance WHERE allowanceid = '" + Convert.Tostring(itemRow.Cells[14].Value) + "'", cn);
                            DataTable bb = new DataTable();
                            da.Fill(bb);
                            }
                        }
                        MessageBox.Show("SuccessFully DELETED.....!");

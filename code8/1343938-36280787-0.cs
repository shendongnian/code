    for (int i = 1; i < dataGridView.Rows.Count; i++)
                            {
                                string sql = @"INSERT INTO ERSBusinessLogic VALUES ('"
                                     + dataGridView.Rows[i].Cells["ERSBusinessLogic_ID"].Value + "', '"
                                    + dataGridView.Rows[i].Cells["ERSBusinessLogic_Formula"].Value + "', '"
                                    + dataGridView.Rows[i].Cells["ERSBusinessLogic_InputsCount"].Value + "', '"
                                    + dataGridView.Rows[i].Cells["ERSBusinessLogic_Inputs"].Value + "');";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                            }

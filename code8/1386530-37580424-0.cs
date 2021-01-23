    ` foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (!chkRow.Checked)
                {
                    con.Open();
                    cmd = new SqlCommand(@"UPDATE JobQuotations1
                                              SET TransactionStatus = @Cancel
                                             WHERE TransactionID = @Tid
                                            AND
                                            TransactionNum = @num", con);
                    cmd.Parameters.AddWithValue("@Cancel", "Cancel");
                    cmd.Parameters.AddWithValue("@Tid", row.Cells[2].Text);
                    cmd.Parameters.AddWithValue("@num", row.Cells[4].Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadDataGrid();
                }
            }`

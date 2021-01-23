     foreach (RepeaterItem rpItem in RepeaterForm.Items)
                {
                    TextBox tFirstname = rpItem.FindControl("txtFirstname") as TextBox;
                    TextBox tLastname = rpItem.FindControl("txtLastname") as TextBox;
                    TextBox tAddress = rpItem.FindControl("txtAddress") as TextBox;
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "spInsFormFields";
                    sqlCmd.Parameters.Clear();
                    if (tFirstname != null)
                        sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = tFirstname.Text;
                    if (tLastname != null)
                        sqlCmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = tLastname.Text;
                    if (tAddress != null)
                        sqlCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = tAddress.Text;
                    sqlCmd.ExecuteNonQuery();
                }

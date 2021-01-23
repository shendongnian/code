      foreach (RepeaterItem rpItem in RepeaterForm.Items)
                {
                    TextBox tFirstname = rpItem.FindControl("txtFirstname") as TextBox;
                    TextBox tLastname = rpItem.FindControl("txtLastname") as TextBox;
                    TextBox tAddress = rpItem.FindControl("txtAddress") as TextBox;
                    if (txtData != null)
                    {
                        sqlCmd.Connection = sqlConn;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "spInsFormFields";
                        sqlCmd.Parameters.Clear();
                        sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = Firstname.Text;
                        sqlCmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = Lastname.Text;
                        sqlCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address.Text;
                        //Code here
    
                        sqlCmd.ExecuteNonQuery();
                    }
                } 

     conn= new OleDbConnection();
        conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=e:\PRTEXT.xls;Extended Properties=Excel 8.0";
        conn.Open();
        string xlsSheet = "PR$";
        adap.UpdateCommand = new OleDbCommand("UPDATE [" + xlsSheet + "] SET FirstName = ?, LastName = ?, Age = ?" +
                                                        " WHERE FirstName = "+ ds.Tables[0].Rows[0][0], conn);
        adap.UpdateCommand.Parameters.Add("@FirstName", OleDbType.Char, 255).SourceColumn = "FirstName";
            adap.UpdateCommand.Parameters.Add("@LastName", OleDbType.Char, 255).SourceColumn = "LastName";
                                              
            adap.UpdateCommand.Parameters.Add("@Age", OleDbType.Char, 255).SourceColumn = "Age";
                                              
            //// Updates the first row
            ds.Tables[0].Rows[0]["FirstName"] = "john";
            ds.Tables[0].Rows[0]["LastName"] = "Statham";
            ds.Tables[0].Rows[0]["Age"] = "55";
 
            adap.Update(ds.Tables[0]);
            conn.Close();
        MessageBox.Show("Updated");

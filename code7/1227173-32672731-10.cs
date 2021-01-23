    private void ddlChanges()
            {
                var con = new SqlConnection("Data Source=.;Initial Catalog=TEST;;User Id=sa;Password=admin@123");
    
                //Get the selected items from the dropdown lists
               var disposeId =  ddlDiposeId.SelectedValue.ToString() == "All" ? null : (int?)Convert.ToIn32(ddlDiposeId.SelectedValue);
               var receiveId = ddlReceiveId.SelectedValue.ToString() == "All" ? null :  (int?)Convert.ToInt32(ddlReceiveId.SelectedValue);
    
                //Create the two parameters for the stored procedures
                var sqlParameters = new []
                    {
                        new SqlParameter("DisposeId", disposeId ?? (object)DBNull.Value),
                        new SqlParameter("ReceiveId", receivedId ?? (object)DBNull.Value)
                    };
    
                //Create the SqlCommand.
                var sqlCommand = new SqlCommand("up_Get_Customers", con);
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlCommand.CommandType = CommandType.StoredProcedure;
    
                var adapter = new SqlDataAdapter(sqlCommand);
                var dataTable = new DataTable();
    
                try
                {
                    con.Open();
                    adapter.Fill(dataTable);
                }
                catch (SqlException sqlException)
                {
                    //Handle errors
                }
                finally
                {
                    con.Close();
                }
            }

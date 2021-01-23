    private void ExecCommand(string commandText, Dictionary<string, object> param)
    {
     using (SqlConnection con = new SqlConnection(DatabaseConnectionString))
     {
         ds = new DataSet("DsToGoOut");
         using (SqlCommand cmd = new SqlCommand(commandText, DbConn.objConn))
         {
             cmd.CommandType = CommandType.StoredProcedure;
             //***************************************
             // New method
             cmd = AddParametersToCommand(cmd, param);
             //***************************************
             try
             {
                 con.Open();
                 SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                 objDataAdapter.SelectCommand = cmd;
                 objDataAdapter.Fill(ds);
                 con.Close();
             }
             catch (Exception ex)
             {
                 //sql_log_err
             }
         }
     }
    }

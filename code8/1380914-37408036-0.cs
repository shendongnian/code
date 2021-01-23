    public void StoredProcedureThatIsBeingcalled(clsStoredProcedure objStoredProcedure)
     {
         using (SqlConnection con = new SqlConnection(objStoredProcedure.ConnectionString))
         {
             ds = new DataSet("DsToGoOut");
             using (SqlCommand cmd = new SqlCommand(objStoredProcedure.Name, DbConn.objConn))
             {
                 cmd.CommandType = CommandType.StoredProcedure;
    foreach (Parameter p in clsStoredProcedure.Parameters)
    {
           cmd.Parameters.Add(new SqlParameter(p.name, p.value));
    }
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

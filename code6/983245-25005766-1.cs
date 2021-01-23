    using(var connection= GetConnectionX()){
    connection.Open();
    for (int i = 0; i < count; i++)
    {
       int num = dataTable.Rows[i]["Location_Id"]
       database.ProcessAlerts("spProcessAlerts", num, connection)
    }
    }
     public SqlServerConnection GetConnectionX()
     {
    
        GeneralLib.GetIniSettings();
        string connectionStrings = GeneralLib.Settings.ConnectionStrings;
        return  new SqlConnection(connectionStrings);
     }
      public void ProcessAlerts(string ProcedureName, int nByLocationId , SqlServerConnection connection)
     {
       try
       {
    
        SqlCommand sqlCommand = new SqlCommand(ProcedureName, connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter sqlParameter = sqlCommand.Parameters.Add("@ByLocation_Id", SqlDbType.Int);
        sqlParameter.Value = nByLocationId;
        sqlCommand.ExecuteNonQuery();
    }
    }

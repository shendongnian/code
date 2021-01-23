    Datatable dt = new Datatable(); 
    try
    {
        using (SqlCeConnection sqlCeConn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["logdbcs"].ToString()))
        {
            SqlCeCommand sqlCeCommand = new SqlCeCommand(@"SELECT * FROM logs", sqlCeConn);
            sqlCeConn.Open();
            sqlCeDataAdapter losqlCeDataAdapter = new sqlCeDataAdapter(sqlCeCommand);
            losqlCeDataAdapter.Fill(dt);
        
            return dt;
        }
    }
    catch (Exception exception)
    {
        Debug.WriteLine(exception.Message);
        throw;
    }

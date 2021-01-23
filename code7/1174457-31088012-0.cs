    Datatable dt = new Datatable(); 
    try
    {
    using (SqlCeConnection sqlCe = new SqlCeConnection(ConfigurationManager.ConnectionStrings["logdbcs"].ToString()))
    {
        SqlCeCommand sqlCeCommand = new SqlCeCommand(@"SELECT * FROM logs", sqlCe);
        sqlCe.Open();
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

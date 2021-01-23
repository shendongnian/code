    sql = @" SELECT * FROM Experience WHERE Colors IN (@param1) ";
    
        DataSet dsColors = new DataSet();
    
        using (OdbcConnection cn =
          new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnMySQL"].ConnectionString))
        {
            cn.Open();
    
            using (OdbcCommand cmd = new OdbcCommand(sql, cn))
            {
    
                cmd.Parameters.AddWithValue("@param1", Server.UrlDecode(str.ToString()));
    
                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                adapter.Fill(dsColors);
            }
        }

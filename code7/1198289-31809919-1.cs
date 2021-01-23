    sql = @" SELECT * FROM Experience WHERE Colors IN (@param1) ";
    
        DataSet dsColors = new DataSet();
    
        using ( MySqlConnection cn =
          new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnMySQL"].ConnectionString))
        {
            cn.Open();
    
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
    
                cmd.Parameters.Add("@param1", Server.UrlDecode(str.ToString()));
    
                MySqlDataAdapter adapter = new MySqlaAdapter(cmd);
                adapter.Fill(dsColors);
            }
        }

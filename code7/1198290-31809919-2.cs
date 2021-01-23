    sql = @" SELECT * FROM Experience WHERE Colors IN (@param1,@param2) ";
    
        DataSet dsColors = new DataSet();
    
        using ( MySqlConnection cn =
          new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnMySQL"].ConnectionString))
        {
            cn.Open();
    
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
    
                cmd.Parameters.Add("@param1", colorList[0]/ToString());
                cmd.Parameters.Add("@param2",colorList[1].ToString());    
                MySqlDataAdapter adapter = new MySqlaAdapter(cmd);
                adapter.Fill(dsColors);
            }
        }

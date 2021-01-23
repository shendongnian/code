    using (MySqlConnection conn = new MySqlConnection(constring))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = conn;
                conn.Open();
    
                cmd.CommandText = "set session sql_mode=traditional;";
                cmd.ExecuteNonQuery();
    
                mb.ExportToFile(file);
                conn.Close();
            }
        }
    }

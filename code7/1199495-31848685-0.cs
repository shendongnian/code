    class DBClass
        {
            MySqlCommand odcmd = new MySqlCommand();
            MySqlConnection odcon = new MySqlConnection();
            MySqlDataAdapter oda = new MySqlDataAdapter();
    
            public DBClass()
            {
                
                odcon.ConnectionString = "Server=localhost;Database=timbangan;Uid=root;Pwd=";
                if (odcon.State == ConnectionState.Closed)
                    odcon.Open();
                oda.SelectCommand = odcmd;
                odcmd.Connection = odcon;            
            }
    
            public DataTable Select(string sql)
            {
                DataTable dt = new DataTable();
                odcmd.CommandText = sql;
                oda.Fill(dt);
                return dt;
            }
    
            public int ModiFy(string sql)
            {
                odcmd.CommandText = sql;
                return odcmd.ExecuteNonQuery();
            }
        }

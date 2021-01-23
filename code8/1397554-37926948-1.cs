    public void FindThatRow(string theDate)
    {   // or all those rows
        // 
    
        using (MySqlConnection lconn = new MySqlConnection(connString))
        {
            lconn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {   // 
                cmd.Connection = lconn;
                cmd.CommandText = @"select id,afspraak_locatie FROM Afspraak WHERE date(datum) = @pTheDate";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@pTheDate", theDate);
                using (MySqlDataReader rs = cmd.ExecuteReader())
                {   //
                    while (rs.Read())
                    {
                        int qId = (int)rs.GetInt32("id");
                        string sViewIt = rs.GetString("afspraak_locatie");
                    }
                }
            }
        }
    }

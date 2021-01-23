       public void ShowGrants(string pUsername, string pHostname)
        {   //  
            string sOut;
            using (MySqlConnection lconn = new MySqlConnection(connString))
            {
                lconn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {   // drewnow
                    cmd.Connection = lconn;
                    cmd.CommandText = "SHOW GRANTS FOR '"+pUsername+"'@'"+pHostname+"'";
                    using (MySqlDataReader rs = cmd.ExecuteReader())
                    {
                        while (rs.Read())
                        {
                            sOut = rs.GetString(0);
                        }
                    }
                }
            }
        }

              using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.3;PORT=3306;UID=username;PWD=password;DATABASE=database_name"))
                    {
                        using (MySqlCommand com = new MySqlCommand("SELECT * FROM cities", con))
                        {
                            DataSet ds = new DataSet();
                            MySqlDataAdapter da = new MySqlDataAdapter(com);
                            da.Fill(ds);
                            foreach (DataRow drow in ds.Tables[0].Rows)
                            {
                                Console.WriteLine("From MySql: " + drow[1].ToString());
                            }
                        }
                    }

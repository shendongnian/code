        {
             string connStr = @"Server=xx98.66;Port=xx6;Database=sxxt;Uid=axx;Pwd=admxxx3z;";
                    MySqlConnection conn = new MySqlConnection(connStr);
            try
        {
             string stm = "SELECT lastUpdated from soccerseason WHERE caption = 'Eredivisie 2015/1'";
            
                        MySqlCommand cmd= conn.CreateCommand();
                        cmd.CommandText = @"SELECT lastUpdated from soccerseason WHERE caption = 'Eredivisie 2015/1'";
                        MySqlDataReader rdr;
                        conn.Open();
                        rdr= cmd.ExecuteReader();
                        DataTable dtsoccer= new DataTable();
                        dtsoccer.Load(rdr);
                        foreach (DataRow row in dtsoccer.Rows)
                        {
                            Console.WriteLine(row["lastUpdated "].ToString());
                        }
                        conn.Close();
                        Console.ReadKey();
                    
          }
                catch (Exception ex)
                {
                    Console.WriteLine("Eccezione =>  " + ex.ToString());
                }
                Console.WriteLine("Done.");
            }
        }

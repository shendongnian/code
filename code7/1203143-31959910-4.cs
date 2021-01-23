    using (SqlConnection connection = new SqlConnection(ConnString))
    {
        using (SqlCommand cmd = connection.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM network";
            cmd.Connection.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                 if (dr .HasRows)
                 {
                      while (dr.Read())
                      {
                        string datasource = dr[1].ToString();
                        string datadestination = dr[2].ToString();
                        if (source == datasource && destination == datadestination)
                        {
                            int newcounter;
                            newcounter = Convert.ToInt32(dr[4]) + 1;
                            Updateddos_network(newcounter);
                        }
                        else
                        {
                            Savedoss_network(source,destination, length, 1);
                        }
                }
                else
                {
                   //No rows found
                }
            }
        }
     }

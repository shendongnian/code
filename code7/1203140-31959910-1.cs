                private void Updateddos_network(int newcounter)
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                       using (SqlCommand cmd = new SqlCommand()
                       {
                         cmd.CommandText = "UPDATE ddos_network set counter = @nnnewcounter";
                         cmd.Parameters.AddWithValue("@nnnewcounter", newcounter);
                         cmd.Connection.Open();
                         cmd.ExecuteNonQuery();
                      }
                    }
                }
                private void Insertddos_network(string source, string destination, int length, int counter)
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                       using (SqlCommand cmd = new SqlCommand()
                       {
                         cmd.CommandText = "INSERT INTO ddos_network(source,destination,length,counter) VALUES (@sssource,@dddestination,@lllength,@cccounter)";
                         cmd.Parameters.AddWithValue("@sssource", source);
                         cmd.Parameters.AddWithValue("@dddestination", destination);
                         cmd.Parameters.AddWithValue("@lllength", length);
                         cmd.Parameters.AddWithValue("@cccounter", counter);
                         cmd.Connection.Open();
                         cmd.ExecuteNonQuery();
                      }
                    }
                }

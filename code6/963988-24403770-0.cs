    private List<Record> GetListOfRecordsToProcess(string exchange, string shareCode, DateTime lastProcessedDate, Indicator indicator)
        {
            List<Record> list = new List<Record>();
            MySqlConnection connection = new MySqlConnection(Data.cs);
            
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand("get_records_to_process", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_exchange", exchange);
                cmd.Parameters.AddWithValue("@p_share_code", shareCode);
                cmd.Parameters.AddWithValue("@p_from_date", lastProcessedDate);
                cmd.Parameters.AddWithValue("@p_num_days", (int)indicator);
                connection.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Record newRecord = new Record(Convert.ToDateTime(reader["trading_date"].ToString()),
                                                      reader["exchange"].ToString(),
                                                      reader["share_code"].ToString(),
                                                      Convert.ToInt32(Convert.ToDouble(reader["close"].ToString())));
                        list.Add(newRecord);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            connection.Close();
            
            return list;
        }

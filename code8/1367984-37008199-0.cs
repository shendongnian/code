    public string[] ExecuteSelect(string query)
        {
            string[] result = { "", "", ""};
            string oradb = "Data Source=FG50OP02;User Id=AUTOEIM;Password=EIM;";
            using (OracleConnection conn = new OracleConnection(oradb))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result[0] = (string)reader["ROW_ID"];
                            result[1] = (string)reader["NAME"];
                            result[2] = (string)reader["LOGIN"];
                        }
                    }
                    else
                    {
                        MessageBox.Show("No rows found.");
                    }
                    reader.Close();
                }
                conn.Dispose();
            }
            return result;
        }

        public bool Insert(Dictionary<string, string> values, string tableName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = $"INSERT INTO {tableName} VALUES({string.Join(", ", values)})"
                    };
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

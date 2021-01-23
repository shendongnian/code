    public DataTable Test(string connectionString)
        {
            DataTable table = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"SELECT ID, UnitType, UnitSN, StatusCode, Priority
                                        FROM Units
                                        WHERE UnitSN = @inputTB;";
                    cmd.Parameters.Add(new SqlParameter(@"inputTB", inputTB.Text));
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        adapter.Fill(table);
                    }
                }
            }
            catch(Exception ex)
            {
            }
            return table;
        }

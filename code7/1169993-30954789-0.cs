    public MyModel RetrieveChancesLeft(string Name)
        {
            MyModel context = new MyModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT [Name], [ChancesLeft] FROM [Credentials] WHERE [Name] = @Name";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters["@Name"].Value = Name;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            context.Chances = Convert.ToInt32(reader["ChancesLeft"]);
                        }
                    }
                }
                conn.Close();
                
            }
            return context;
        }

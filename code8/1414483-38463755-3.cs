                string teamName = string.Empty;
                using (SqlConnection connection = new SqlConnection("your connection string"))
                {
                    connection.Open();
    
                    string query = "SELECT DISTINCT team_name FROM sec WHERE job = @job";
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@job",
                        Value = TextBox1.Text
                    };
    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(param);
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
                        
                        if (reader.Read())
                        {
                            teamName = reader.GetString(0);
                            // or
                            int ord = reader.GetOrdinal("team_name");
                            teamName = reader.GetString(ord); // Handles nulls and empty strings.
                        }
                    }
                }

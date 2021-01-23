     using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("select 1", conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string a = "teste";
                }
            }

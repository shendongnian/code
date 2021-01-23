    static float ExecuteQueryWithResult_fl(SqlConnection connection, string query)
        try {{
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                var prev_val = ((float)command.ExecuteScalar());
                return prev_val;
            }
        }}
       catch (Exception x) { Console.WriteLine("Error fetching due to {0}", x.Message); }

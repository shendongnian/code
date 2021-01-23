    using (SqlConnection conn = new SqlConnection("connectionString"))
            {
                // Open Connection
                conn.Open();
                // Define Sql Command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SQL Query";
                cmd.Connection = conn;
                // Your Adapter, Editted you are insert not get Data Comment
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery()
                // Do your thing here
            }

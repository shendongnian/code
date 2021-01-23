    string queryString = "select  sys.get_enc_val ('" + txtpassword.Text + "', 'F20FA982B4C2C675')  from dual";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",reader[0], reader[1]));
                }
            }
            finally
            {
                reader.Close();
            }
        }

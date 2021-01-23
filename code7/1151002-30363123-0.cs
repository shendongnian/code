    using (var connection = new SqlConnection())
    {
        connection.ConnectionString = "Your Connection String";
        using (var command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "scUsuarioCorrecto";
            command.Parameters.AddWithValue("@usrLogin", "Your login");
            command.Parameters.AddWithValue("@usrPassword", "Your password");
            
            connection.Open();
            using (var adapter = new SqlDataAdapter())
            {
                using (var ds = new DataSet())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0 && ds.Tables.Rows.Count > 0)
                    {
                        var correcto = (bool)ds.Tables[0].Rows[0]["correcto"];
                    } else
                    {
                        // Something went wrong
                    }
                }
            }
        }
    }

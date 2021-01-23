    using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlCommandBuilder.DeriveParameters(command);
                    //instead of        command.Parameters.AddWithValue("@Param",value);
                     command.Parameters["@Param"].Value = value;

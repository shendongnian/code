    while (reader.Read())
            {
                using(SqlCommand storedProcCommand = new SqlCommand("addToNotificationTable", connection)) //Specify only the SP name
                { 
                    storedProcCommand.CommandType = CommandType.StoredProcedure; //Indicates that Command to be executed is a stored procedure no a query
                    var paramId = new SqlParameter("@ID", reader.GetInt32(0));
                    storedProcCommand.Parameters.Add(paramId);
                    storedProcCommand.ExecuteNonQuery()
                }
            }

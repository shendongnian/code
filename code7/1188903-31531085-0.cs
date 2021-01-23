    while (reader.Read())
            {
                var storedProcCommand = new SqlCommand("EXEC addToNotificationTable @ID", connection);
                var paramId = new SqlParameter("@ID", reader.GetInt32(0));
                storedProcCommand.Parameters.Add(paramId);
                storedProcCommand.ExecuteNonQuery();
            }

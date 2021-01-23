    Using connection As New SqlConnection(connectionString)
      Using command As New SqlCommand(queryString, connection)
        command.Connection.Open()
        command.CommandType = // Typically Text or StoredProcedure as needed
        command.Parameters.AddWithValue("@parameter_name1", some_value_1)
        command.Parameters.AddWithValue("@parameter_name2", some_value_2)
        .
        .
        .
        command.ExecuteNonQuery()
      End Using
    End Using

    public string GetFilePathUri(SqlConnection connection, SqlTransaction    transaction)
    {
        string filePathUri = "";
        using (var command = new SqlCommand(FILEPATH_SPROC, connection) {CommandType = CommandType.StoredProcedure, Transaction = transaction})
        {
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                filePathUri = reader["Path"].ToString();
            }
            reader.Close();//Closing the reader
        }
        return filePathUri;
    }

    public foo Dequeue(SqlConnection connection, SqlTransaction transaction)
    {
        using (var command = new SqlCommand(DEQUEUE_SPROC, connection) {CommandType = CommandType.StoredProcedure, Transaction = transaction})
        {
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                ID = (Guid) reader["ID"];
                Name = reader["Name"].ToString();
                reader.Close();//Closing the reader
                return this;
            }
            return null;
        }
    }
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

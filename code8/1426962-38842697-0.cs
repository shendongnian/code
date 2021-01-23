    ...
    var query = "INSERT INTO MY_TABLE VALUES (?, ?, ?, ?, ?)";
    using (var insertCmd = new OleDbCommand(query, conn))
    {
        insertCmd.CommandType = CommandType.Text;
        insertCmd.Parameters.AddRange(new OleDbParameter[]
        {
            new OleDbParameter("?", FindItemId(filePath)),
            new OleDbParameter("?", filePath),
            new OleDbParameter("?", new FileInfo(filePath).Name),
            new OleDbParameter("?", new FileInfo(filePath).Length),
            new OleDbParameter("?", GetMd5Hash(filePath))
        });
        insertCmd.ExecuteNonQuery();
    }
    ...

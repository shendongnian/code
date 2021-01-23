    ...
    var query = "INSERT INTO MY_TABLE VALUES (?, ?, ?, ?, ?)";
    using (var insertCmd = new OleDbCommand(query, conn))
    {
    insertCmd.CommandType = CommandType.Text;
    insertCmd.Parameters.AddRange(new OleDbParameter[]
    {
        new OleDbParameter("@id", FindItemId(filePath)),
        new OleDbParameter("@filepath", filePath),
        new OleDbParameter("@filename", new FileInfo(filePath).Name),
        new OleDbParameter("@filesize", new FileInfo(filePath).Length),
        new OleDbParameter("@md5", GetMd5Hash(filePath))
    });
    insertCmd.ExecuteNonQuery();
    }
    ...

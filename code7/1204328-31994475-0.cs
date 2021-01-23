    List<string> ids = new List<string>{"qwe", "asd", "zxc"};
    string sqlQuery = "select id from user where id IN (@id1, @id2, @id3)";
    sqlCommand.Parameters.Add("@id1", SqlDbType.VarChar).Value = ids[0];
    sqlCommand.Parameters.Add("@id2", SqlDbType.VarChar).Value = ids[1];
    sqlCommand.Parameters.Add("@id3", SqlDbType.VarChar).Value = ids[2];

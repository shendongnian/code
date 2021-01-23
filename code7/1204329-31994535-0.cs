    List<string> ids = new List<string>{"qwe", "asd", "zxc"};
    string sqlQuery = "select id from user where id IN(";
    for(int i=0; i < ids.Count; i++)
    {
        sqlQuery += "@Id"+ i + ",";
        sqlCommand.Parameters.Add("@ids", SqlDbType.varchar).Value = ids[i];
    }
    sqlQuery = sqlQuery.TrimEnd(",") + ")";

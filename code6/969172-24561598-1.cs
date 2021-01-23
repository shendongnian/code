    int i = 0;
    List<string> clauses = new List<string>() {"(@key0, @value0)"};
    List<SqlParameter> paramList = new List<SqlParameter> {
        new SqlParameter("@key0", DBNull.Value), 
        new SqlParameter("@value0", "asd")
    };
    for (i = 1; i < listSize; i++) {
        clauses.Add("(@key" + i + ", @value" + i + ")");
        paramList.Add(new SqlParameter("@key" + i, someKey));
        paramList.Add(new SqlParameter("@value" + i, someValue);
    }
    SqlConnection conn = new SqlConnection(connString);
    SqlCommand command = new SqlCommand(conn, @"INSERT INTO table1 VALUES " + String.Join(", ", clauses);
    foreach(SqlParameter param in paramList) command.Parameters.Add(param);
    command.ExecuteNonQuery();

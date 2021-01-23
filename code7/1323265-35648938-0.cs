    var fileContent = File.ReadAllText("query.sql");
    var sqlqueries = fileContent.Split(new[] {" GO "}, StringSplitOptions.RemoveEmptyEntries);
     
    var con = new SqlConnection("connstring");
    var cmd = new SqlCommand("query", con);
    con.Open();
    foreach (var query in sqlqueries)
    {
        cmd.CommandText = query;
        cmd.ExecuteNonQuery();
    }
    con.Close();

    string connStr = "server=.;database=Test;Integrated security=SSPI;";
    string insertQry = "INSERT INTO dbo.Foo(time) VALUES(@Time);";
    using (SqlConnection conn = new SqlConnection(connStr))
    using (SqlCommand insertCmd = new SqlCommand(insertQry, conn))
    {
        // use proper Parameters syntax - specify SqlDbType!
        insertCmd.Parameters.Add("@time", SqlDbType.Time).Value = TimeSpan.Parse("00:03:28.385");
        conn.Open();
        insertCmd.ExecuteNonQuery();
        conn.Close();
    }

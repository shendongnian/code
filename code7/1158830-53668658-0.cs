    using Z.BulkOperations;
......
    MySqlConnection conn = DbConnection.OpenConnection();
    DataTable dt = new DataTable("testtable");
    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM testtable", conn);
    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
    da.Fill(dt);

    var builder = new SqlConnectionStringBuilder();
    builder.WorkstationID = "Server";
    builder.DataSource = "DataBase";
    builder.UserID = "User";
    builder.Password = "Password";
    using (var connection = new SqlConnection(builder.ConnectionString))
    {
        var command = new SqlCommand("Select Field1, Field2, Field3 From Table", connection);
        var adapter = new SqlDataAdapter(command);
        var dataTable = new DataTable("Table");
        adapter.Fill(dataTable);
        var dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
    }

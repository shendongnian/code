    var result = new List<Blog>();
    var connection = @"your connection string";
    var command = "SELECT * FROM Kristina_Blogs";
    var adapter = new System.Data.SqlClient.SqlDataAdapter(command, connection);
    var dataTable = new DataTable();
    //Get data
    adapter.Fill(dataTable);
    dataTable.Rows.Cast<DataRow>().ToList()
                .ForEach(row =>
                {
                    var b = new Blog();
                    b.Id = row.Field<int>("Id");
                    b.Title = row.Field<string>("Title");
                    b.Message = row.Field<string>("Message");
                    result.Add(b);
                });
    return result;

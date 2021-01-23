    public ResultModel GetData()
    {
        var connection = @"data source=(localdb)\v11.0;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True;";
        var command = "dbo.Procedure";
        var tableAdapter = new System.Data.SqlClient.SqlDataAdapter(command, connection);
        tableAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        var dataSet = new DataSet();
        tableAdapter.Fill(dataSet); 
        var t1 = dataSet.Tables[0].Rows.Cast<DataRow>()
            .ToList().Select(row => new Type1
            {
                A = row.Field<int>("A"),
            }).ToList();
        var t2 = dataSet.Tables[1].Rows.Cast<DataRow>()
            .ToList().Select(row => new Type2
            {
                B = row.Field<int>("B"),
                C = row.Field<string>("C")
            }).ToList();
        var t3 = dataSet.Tables[1].Rows.Cast<DataRow>()
            .ToList().Select(row => new Type3
            {
                D = row.Field<int>("D"),
                E = row.Field<string>("E"),
                F = row.Field<string>("F")
            }).ToList();
        var result = new ResultModel() { List1 = t1, List2 = t2, List3 = t3 };
        return result;
    }

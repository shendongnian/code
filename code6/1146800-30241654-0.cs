    using (var dataAdapter = new SqlDataAdapter(command))
    {
        var parameter = new SqlParameter();
        parameter.ParameterName = "@NumberList";
        parameter.SqlDbType = SqlDbType.Structured;
        parameter.Value = numberList;
        //ADD THIS
        command.Parameters.Add(parameter);
        dataAdapter.Fill(dataTable);
    }

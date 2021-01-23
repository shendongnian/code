    var parameter = new SqlParameter();
    parameter.SqlDbType = SqlDbType.Structured;
    parameter.ParameterName = "@UserIds";
    parameter.Value = table;
    var parameters = new SqlParameter[1]
    {
      parameter
    };

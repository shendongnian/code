    Assume, com is SqlCommand and ExchangeRate is Parameter
    SqlParameter parameter = new SqlParameter("@ExChangedRate", SqlDbType.Decimal);
    parameter.Direction = ParameterDirection.Output;
    parameter.Precision = 16;
    parameter.Scale = 2;
    com.Parameters.Add(parameter);

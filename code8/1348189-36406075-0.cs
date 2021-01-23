    <!-- language: c# -->
        SqlParameter paramAge = new SqlParameter();
        paramAge.Value = strAirline;
        paramAge.Direction = ParameterDirection.Input;
        paramAge.SqlDbType = SqlDbType.NVarChar;
        paramAge.ParameterName = "@strAirline";

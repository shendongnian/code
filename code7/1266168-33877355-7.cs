    someDataTable = SqlDBHelper.ExecuteDataSet("sp_ViewProductUsage_MappingRS", CommandType.StoredProcedure,
    			new SqlParameter() { ParameterName = "@Unit", SqlDbType = SqlDbType.VarChar, Value = _unit },
    			new SqlParameter() { ParameterName = "@BegDate", SqlDbType = SqlDbType.DateTime, Value = dtBegin },
    			new SqlParameter() { ParameterName = "@EndDate", SqlDbType = SqlDbType.DateTime, Value = dtEnd }
    			);

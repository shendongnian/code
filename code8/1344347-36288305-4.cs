    DataTable dtDeliveryPerformanceResults = 
        SQLDBHelper.ExecuteSQLReturnDataTable(
            PLATYPUS_STOREDPROC,
            CommandType.StoredProcedure,
            new SqlParameter()
            {
                ParameterName = "@Unit",
                SqlDbType = SqlDbType.VarChar,
                Value = unit
            },
            new SqlParameter()
            {
                ParameterName = "@BeginDate",
                SqlDbType = SqlDbType.DateTime,
                Value = _begDate
            },
            new SqlParameter()
            {
                ParameterName = "@EndDate",
                SqlDbType = SqlDbType.DateTime,
                Value = _endDate
            },
            new SqlParameter()
            {
                ParameterName = "@PoisonToeLength",
                SqlDbType = Convert.ToInt32(SqlDbType.Int),
                Value = 42
            }
        );

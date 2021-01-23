    public static DataTable GetData(String extractToRun, DateTime startDate, DateTime endDate)
    {
        //RefCursor
        OracleParameter refCursorOracleParameter = new OracleParameter
                                                {
                                                    ParameterName = "pCursor",
                                                    Direction = ParameterDirection.Output,
                                                    OracleDbType = OracleDbType.RefCursor
                                                };
        OracleParameter startDateOracleParameter = new OracleParameter
        {
            ParameterName = "pStartDate",
            Direction = ParameterDirection.Input,
            OracleDbType = OracleDbType.Varchar2,
            Value =   startDate
        };
        OracleParameter endDateOracleParameter = new OracleParameter
        {
            ParameterName = "pEndDate",
            Direction = ParameterDirection.Input,
            OracleDbType = OracleDbType.Varchar2,
            Value =   endDate
        };
        OracleParameter jobIdOracleParameter = new OracleParameter
        {
            ParameterName = "pJobId",
            Direction = ParameterDirection.Input,                
            Value =   "123456"
        };
        using (var oracleConnection = new OracleConnection(ContextInfo.ConnectionString))
        {
            oracleConnection.Open();
            try
            {
                using (var oracleCommand = new OracleCommand(extractToRun, oracleConnection))
                {
                    oracleCommand.CommandType = CommandType.StoredProcedure;
                    oracleCommand.BindByName = true;
                    oracleCommand.FetchSize = oracleCommand.FetchSize * 128;
                    oracleCommand.InitialLONGFetchSize = 5000;
                    oracleCommand.Parameters.Add(refCursorOracleParameter);
                    oracleCommand.Parameters.Add(startDateOracleParameter);
                    oracleCommand.Parameters.Add(endDateOracleParameter);
                    oracleCommand.Parameters.Add(jobIdOracleParameter);
                    using (OracleDataReader rdr = oracleCommand.ExecuteReader())
                    {
                        rdr.FetchSize = rdr.RowSize * 65536;
                        DataTable dt = new DataTable();
                        dt.MinimumCapacity = 400000;
                        dt.BeginLoadData();
                        dt.Load(rdr, LoadOption.Upsert);
                        dt.EndLoadData();
                        rdr.Close();
                        rdr.Dispose();
                        oracleCommand.Dispose();
                        return dt;
                    }
                }
            }
            finally
            {
                oracleConnection.Close();
                oracleConnection.Dispose();
            }
        }
    }

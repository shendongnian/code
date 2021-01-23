    public static List<ROW_DATA> GetData(String extractToRun, DateTime startDate, DateTime endDate)
    {
        List<ROW_DATA> dataTable = new List<ROW_DATA>();
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
                        //byte[] columnBytes = new byte[16384];
                        Int32 tryCount = 0;
                        rdr.FetchSize = rdr.RowSize * 262144;
                                while (rdr.Read())
                                {
                                    Int32 charLength = (Int32)rdr.GetChars(0, 0, null, 0, 0);
                                    char[] colChars = new char[charLength];
                                    rdr.GetChars(0, 0, colChars, 0, charLength);
                                    //OracleString colValue = rdr.GetOracleString(0);
                                    //int valueLength = colValue.Length;
                                    //unsafe
                                    //{
                                    //    fixed (char* pcolValue = colValue.Value)
                                    //    {
                                    //        fixed (byte* pcolBytes = columnBytes)
                                    //        {
                                    //            for (int i = 0; i < valueLength; i++)
                                    //            {
                                    //                pcolBytes[i] = (byte)pcolValue[i];
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    ROW_DATA rowData = new ROW_DATA { length = charLength, rowValues = colChars };
                                    dataTable.Add(rowData);
                        }
                        rdr.Close();
                        rdr.Dispose();
                        oracleCommand.Dispose();
                        return dataTable;
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

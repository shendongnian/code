    public static DataTable ExecuteProc(string procedureName, Object[] parameterList, string SQLConnectionString) // throws SystemException
            {
                DataTable outputDataTable;
    
                using (SqlConnection sqlConnection = OpenSQLConnection(SQLConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
    
                        if (parameterList != null)
                        {
                            for (int i = 0; i < parameterList.Length; i = i + 2)
                            {
                                string parameterName = parameterList[i].ToString();
                                object parameterValue = parameterList[i + 1];
    
                                sqlCommand.Parameters.Add(new SqlParameter(parameterName, parameterValue));
                            }
                        }
    
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataSet outputDataSet = new DataSet();
                        try
                        {
                            sqlDataAdapter.Fill(outputDataSet, "resultset");
                        }
                        catch (SystemException systemException)
                        {
                            // The source table is invalid.
                            throw systemException; // to be handled as appropriate by calling function
                        }
    
                        outputDataTable = outputDataSet.Tables["resultset"];
                    }
                }
    
                return outputDataTable;
            }

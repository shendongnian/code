    public DataTable ExecuteStoredProcedure(string storedProcedure, List<StoredProcedureParameters> storedProcedureParameters, bool withForEach)
        {
            var dataTable = new DataTable();
            using (var odbcConnection = _connection)
            {
                using (var odbcCommand = odbcConnection.CreateCommand())
                {
                    odbcCommand.CommandText = storedProcedure;
                    if(withForEach)
                    foreach (var parameter in storedProcedureParameters)
                    {
                        odbcCommand.Parameters.Add("@" + parameter.ParameterName, parameter.ParameterType, 
                            parameter.LengthOfParameter).Value = parameter.ParameterName;
                    }
    
                    odbcCommand.CommandType = CommandType.StoredProcedure;
                    using (var adapter = new OdbcDataAdapter(odbcCommand))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
    
            return dataTable;
        }

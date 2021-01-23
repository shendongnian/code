    DataSet dataSet = new DataSet("ReturnDs");
    using (var connection = new System.Data.SqlClient.SqlConnection(theConnectStg))
    {
        using (var command = new System.Data.SqlClient.SqlCommand(theStoreProcName, connection))
        {
            using (var dataAdapter = new System.Data.SqlClient.SqlDataAdapter(command))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (theParameterList != null)
                {
                    foreach (String str1 in theParameterList.ToArray())
                    {
                        String parameterName = str1.Substring(0, str1.IndexOf(":"));
                        String str2 = str1.Substring(str1.IndexOf(":") + 1);
                        dataAdapter.SelectCommand.Parameters.Add(new SqlParameter(parameterName, SqlDbType.VarChar, 128));
                        dataAdapter.SelectCommand.Parameters[parameterName].Value = (object)str2;
                    }
                }
                dataAdapter.Fill(dataSet);
            }
        }
    }
    return dataSet;

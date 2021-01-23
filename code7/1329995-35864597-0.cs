    public static int CallExecuteNonQuery(string storeProcName, Action<SqlCommand> fillParamsAction, Action afterExecution, BDDSource source)
    {
        int result = 0;
        var exceptions = new List<Exception>();
        while(true)
        {
            try
            {
                using (var connection = InitSqlConnection(source))
                using (var command = new SqlCommand(storeProcName, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    if (fillParamsAction != null)
                        fillParamsAction(command);
                    result = command.ExecuteNonQuery();
                    if (afterExecution != null)
                        afterExecution();
                }
                break;
            }
            catch (SqlException sqlExn)
            {
                if (sqlExn.Errors.Cast<SqlError>().All(x => (x.Class >= 16 && x.Class < 22) || x.Class == 24))
                {
                    exceptions.Add(sqlExn);
                    if (exceptions.Count == Properties.Settings.Default.Request_MaximumRetry)
                    {
                        throw new AggregateException("Too many attempts.", exceptions);
                    }
                    continue;
                }
                Logger.Exception(string.Format("SQL CRITICAL ERROR. StoreProcName : {0}", storeProcName), sqlExn);
                throw;
            }
            catch (Exception exception)
            {
                Logger.Exception(string.Format("SOFTWARE CRITICAL ERROR. StoreProcName : {0}", storeProcName), exception);
                throw;
            }
        }
        return result;
    }

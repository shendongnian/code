    public static int CallExecuteNonQuery(string storeProcName, Action<SqlCommand> fillParamsAction, Action afterExecution, BDDSource source)
    {
        int retryCount = 0;   // recoverable exception will be rethrown 
                              // when this count reaches limit
        while (true)   // conditions for breaking out of loop inlined
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
                    var result = command.ExecuteNonQuery();
                    if (afterExecution != null)
                        afterExecution();
                    return result;   // on success, return immediately
                }
            }
            catch (SqlException sqlExn)
            {
                // if error is recoverable, and retry count has not exceeded limit,
                // then retry operation
                if (sqlExn.Errors.Cast<SqlError>().All(x => (x.Class >= 16 && x.Class < 22) || x.Class == 24)
                    && ++retryCount < Properties.Settings.Default.Request_MaximumRetry)
                {
                    continue;
                }
                // otherwise, rethrow exception
                Logger.Exception(string.Format("SQL CRITICAL ERROR. StoreProcName : {0}", storeProcName), sqlExn);
                throw;
            }
            catch (Exception exception)
            {
                Logger.Exception(string.Format("SOFTWARE CRITICAL ERROR. StoreProcName : {0}", storeProcName), exception);
                throw;
            }
        }
    }

    public static class ObservableEx
        {
            public static IObservable<T> CreateFromSqlCommand<T>(string connectionString, string command, Func<SqlDataReader, Task<T>> readDataFunc)
            {
                return CreateFromSqlCommand(connectionString, command, readDataFunc, CancellationToken.None);
            }
    
            public static IObservable<T> CreateFromSqlCommand<T>(string connectionString, string command, Func<SqlDataReader, Task<T>> readDataFunc, CancellationToken cancellationToken)
            {
                return Observable.Create<T>(
                    async o =>
                    {
                        SqlDataReader reader = null;
    
                        try
                        {                        
                            using (var conn = new SqlConnection(connectionString))
                            using (var cmd = new SqlCommand(command, conn))
                            {
                                await conn.OpenAsync(cancellationToken);
                                reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, cancellationToken);
    
                                while (await reader.ReadAsync(cancellationToken))
                                {
                                    var data = await readDataFunc(reader);
                                    o.OnNext(data);                                
                                }
    
                                o.OnCompleted();
                            }
                        }
                        catch (Exception ex)
                        {
                            o.OnError(ex);
                        }
    
                        return reader;
                    });
            }
        }

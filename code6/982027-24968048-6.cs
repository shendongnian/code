    private static IObservable<Data> ReadData()
    {
        return Observable.Create<Data>(
            async o =>
            {
                SqlDataReader reader = null;
                try
                {
                    using (var conn = new SqlConnection(connectionString))
                    using (var cmd = new SqlCommand("select * from Data", conn))
                    {
                        await conn.OpenAsync();
                        reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                        while (await reader.ReadAsync())
                        {
                            var data = new Data();
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

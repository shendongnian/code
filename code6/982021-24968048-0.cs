    private static IObservable<Data> ReadData()
    {
        return Observable.Create<Data>(
            o =>
            {
                using(var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("select * from Data", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        var data = new Data();
                        o.OnNext(data);
                    }
    
                    o.OnCompleted();
    
                    return reader;
                }
            });
    }

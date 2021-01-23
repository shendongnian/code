    public async void ReadAsync(..., Action<Data> processor)
    {
        using(var connection = new SqlConnection(...))
        {
            // note you can use connection.OpenAsync()
            // and command.ExecuteReaderAsync() here
            while(await reader.ReadAsync())
            {
                // ...
                processor(item);
            }
        }
    }

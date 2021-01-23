    public void Read(..., Action<Data> processor)
    {
        using(var connection = new SqlConnection(...))
        {
            // ...
            while(reader.Read())
            {
                // ...
                processor(item);
            }
        }
    }

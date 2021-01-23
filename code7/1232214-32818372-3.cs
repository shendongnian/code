    void BulkInsert<T>(object p)
    {
        IEnumerator<T> e = (IEnumerator<T>)p;
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            while(true)
            {
                T item;
                lock(e)
                {
                    if (!e.MoveNext())
                        return;
                    item = e.Current;
                }
                var result = sqlConnection.Execute(myQuery, new { ... } );
            }
        }
    }

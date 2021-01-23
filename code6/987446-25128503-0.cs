    var sqlConnection = this.connectionPool.Take();
    try
    {
        // Other stuff here...
        using (var reader = this.selectWithSourceVectorCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                yield return ReaderToVectorTransition(reader);
            }
        }
    }
    finally
    {
        this.connectionPool.Putback(sqlConnection);
    }

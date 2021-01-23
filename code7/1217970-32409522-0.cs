    using (IDbCommand selectCommand = this.createCommand(selectSQL))
    {
        using (IDataReader theData = selectCommand.ExecuteReader())
        {
        }
    }

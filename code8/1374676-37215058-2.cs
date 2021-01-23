    private object CompleteExecuteScalar(SqlDataReader ds, bool returnSqlValue)
    {
        object obj2 = null;
        try
        {
            if (!ds.Read() || (ds.FieldCount <= 0))
            {
                return obj2;
            }
            if (returnSqlValue)
            {
                return ds.GetSqlValue(0);
            }
            obj2 = ds.GetValue(0);
        }
        finally
        {
            ds.Close();
        }
        return obj2;
    }

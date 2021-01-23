    EntityConnection ec = (EntityConnection)Context.Connection;
    SqlConnection sc = (SqlConnection)ec.StoreConnection;
    SqlTransaction sqlTransaction = null;
    var parserProp = sc.GetType().GetProperty("Parser", BindingFlags.NonPublic | BindingFlags.Instance);
    if (parserProp != null)
    {
        var parser = parserProp.GetValue(sc, null);
        var sqltxProp = parser.GetType().GetProperty("CurrentTransaction", BindingFlags.NonPublic | BindingFlags.Instance);
        var currentTransaction = sqltxProp.GetValue(parser, null);
        sqlTransaction = currentTransaction as SqlTransaction;
        if (sqlTransaction == null)
        {
            var parentProp = currentTransaction.GetType().GetProperty("Parent", BindingFlags.NonPublic | BindingFlags.Instance);
            currentTransaction = parentProp.GetValue(currentTransaction, null);
            sqlTransaction = currentTransaction as SqlTransaction;
        }
    }

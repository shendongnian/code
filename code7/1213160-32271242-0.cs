    [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = false, IsPrecise = true)]
    public static SqlBoolean GetIfSmallInt(object SomeValue)
    {
        return (SomeValue.GetType() == typeof(SqlInt16));
    }

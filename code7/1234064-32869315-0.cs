    public static Task<IEnumerable<object>> QueryAsync(this IDbConnection cnn, 
        Type type, CommandDefinition command)
    {
        return QueryAsync<object>(cnn, type, command);
    }

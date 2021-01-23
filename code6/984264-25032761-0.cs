    public int Delete(string query)
    {
        using (new SessionIdLoggingContext(SessionId))
        {
            return Delete(query, NoArgs, NoTypes);
        }
    }
    public int Delete(string query, object value, IType type)
    {
        using (new SessionIdLoggingContext(SessionId))
        {
            return Delete(query, new[] {value}, new[] {type});
        }
    }

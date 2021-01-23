    public T GetEntity<T>(Guid entityId, string connectionString)
        where T : class
    {
        using (RContext rpContext = new RContext(connectionString))
        {
            return rpContext.Set<T>().FirstOrDefault(e => e.Id == entityId);
        }
    }

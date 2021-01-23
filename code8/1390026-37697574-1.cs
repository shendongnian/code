    public T GetEntity<T>(Guid entityId, string connectionString)
        where T : class
    {
        using (RContext rpContext = new RContext(connectionString))
        {
            return (from e in rpContext.Set<T>()
                    where e.Id == entityId
                    select e).FirstOrDefault();
        }
    }

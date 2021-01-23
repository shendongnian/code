    private static object _lock = new object();
    public IRapportBestilling GetNextReportOrderAndLock(...)
    {
        ...
        using (var scope = new QueryEngineSessionScope())
        {
            lock(_lock)
            {
                ...
            }
        }
    }

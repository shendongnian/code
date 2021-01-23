    public static class ActivityFactory
    {
    public static DbSet<T> GetDbSet<T>(BAMContext context, 
                 BizTalkApplicationEnum previousApplication) where T: class, IActivity
    {
        switch (previousApplication)
        {
            case BizTalkApplicationEnum.Erp:
                return context.ErpRecs;
            case BizTalkApplicationEnum.Scip:
                return context.ScipRecs;
        }
        return null;
    }
    }

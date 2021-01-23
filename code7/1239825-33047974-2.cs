    using System.Linq.Expressions;
    protected int getManagerCount(string managerName, Expression<InfoSet> predicate)
    {
        using (var context = new InfoDBContext())
        {
            int managerDoneCount = context.InfoSet
                    .Where(predicate)
                    .GroupBy(x => x.ww)
                    .Count();
    
            return managerDoneCount;
        }
    }

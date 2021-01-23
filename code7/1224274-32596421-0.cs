    public IQueryable<Resource> GetResources()
    {      
           MyContext ctx = new MyContext ();
           IEnumerable<Expression<Func<Resource, bool>>> queries =
                filterValuesForUser.GroupBy(x => x.FilterGroup)
                .Select(filter => SecurityFilters.FilterResourcesByUserCriteriaEF(filter.Select(y => y.FilterValue1)))
                .Select(filterExpression => { return filterExpression; });
       Expression<Func<Resource, bool>> query = PredicateBuilder.True<Resource>();
            foreach (Expression<Func<Resource, bool>> filter in queries)
            {
                query = query.And(filter);
            }
            return ctx.Resources.AsExpandable().Where(query);
    }      

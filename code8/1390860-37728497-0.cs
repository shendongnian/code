    using ( var context = new MyDbContext() )
    {
        Expression<Func<Rules, bool>> whereCondition;
        if (!string.IsNullOrEmpty( searchTerm ) )
        {
            whereCondition= x.RuleValue.Contains(searchTerm));
        }
        var query = context.Rules
                           .Where(whereCondition)
                           .Select(x=> new 
                           {
                             rules = x,
                             exclustions = x.Exclusions.Where(secondCondition).ToList()
                           }.ToList();
    }

    Expression<Func<Products, bool>> expresionFinal = p => p.Active;
            
    if (mydate.HasValue)
    {
        Expression<Func<Products, bool>> expresionDate = p => (EntityFunctions.TruncateTime(c.CreatedDate) <= mydate);
        expresionFinal = PredicateBuilder.And(expresionFinal, expresionDate );
    }
    
    IQueryable<T> query = dbSet;
    
        query = query.Where(expresionFinal);

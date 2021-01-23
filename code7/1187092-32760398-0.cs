         Expression<Func<Products, bool>> expresionFinal = p => p.Active;
        
        if (mydate.HasValue)
        {
            Expression<Func<Products, bool>> expresionDate = p => (EntityFunctions.TruncateTime(c.CreatedDate) <= mydate);
            expresionFinal = PredicateBuilder.And(expresionFinal, expresionDate );
        }
    
    if (!String.IsNullOrEmpty(codeProduct))
                    {
                        Expression<Func<Products, bool>> expresionCode = c => (codeProduct== c.codProduct);
                        expresionFinal = PredicateBuilder.And(expresionFinal, expresionCode );
                    }
        
        IQueryable<T> query = dbSet;
        
        
            query = query.Where(expresionFinal);

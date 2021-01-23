            Expression<Func<Products, bool>> expresionFinal = p => p.Active;
            
         if (mydate.HasValue)
                        {
                            Expression<Func<Products, bool>> expresionDate = p => (EntityFunctions.TruncateTime(c.CreatedDate) <= mydate);
                            expresionFinal = PredicateBuilder.And(expresionFinal, expresionDate );
                        }
    
    IQueryable<T> query = dbSet;
    
                if (expresionFinal!= null)
                    query = query.Where(expresionFinal);

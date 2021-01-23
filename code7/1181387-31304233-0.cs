    protected override IQueryable<T> Execute<T>(IQueryable<T> original, string propertyName)
    {
       var parameter = Expression.Parameter(typeof(T));
       var property = Expression.PropertyOrField(parameter, propertyName);
       var constant = Expression.Constant(Name);
    
       Expression predicate;
       if(RequestExactMatch())  
       {     
    	  predicate = Expression.Equal(property, constant);    
       }
       else 
       {
    	  predicate = Expression.Call(property, "Contains", null, constant);    
       }
    
       var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);
       return original.Where(lambda);
    }

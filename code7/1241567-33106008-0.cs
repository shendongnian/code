    // Source code
    IQueryable<Clients> source = null;
    IQueryable<Clients> result = source.Where(c => c.LocationTypeId >= 1);
    
    // Compiller generated code
    IQueryable<Clients> source = null;
    
    Expression parameterC = Expression.Parameter(typeof(Clients), "c");
    
    IQueryable<Clients> result = Queryable.Where<Clients>(
        source,
        Expression.Lambda<Func<Clients, bool>>(
            Expression.LessThanOrEqual(
                Expression.Property(
                    parameterC ,
                    typeof(Clients).GetProperty("LocationTypeId").GetGetMethod()
                    ),
                Expression.Constant(1, typeof(int))
                ),
    	new ParameterExpression[]
            {
                parameterC 
            }
        );

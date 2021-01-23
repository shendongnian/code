    public static IQueryable<TypeTwo> Tester(IQueryable<TypeOne> data)
    {
    	var source = Expression.Parameter(typeof(TypeOne), "source");
    	var selector = Expression.Lambda<Func<TypeOne, TypeTwo>>(
    		Expression.MemberInit(Expression.New(typeof(TypeTwo)),
    			Expression.Bind(typeof(TypeTwo).GetProperty("TwoProp"), Expression.Property(source, "OneProp"))),
    		source);
    	return data.Select(selector);
    }

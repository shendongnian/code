    void Main()
    {
    	Expression<Func<IEnumerable<FieldInfo>, Func<FieldInfo,bool>, FieldInfo>> singleOrDefaultExpr = (l,p) => l.SingleOrDefault(p);
    	var callSource = (MethodCallExpression)singleOrDefaultExpr.Body;
    	
    	var method = callSource.Method;
    	
    	var collectionParameter = Expression.Parameter(typeof(IEnumerable<FieldInfo>), "enumFieldInfoSet");
    	var enumNamePredicateParameter = Expression.Parameter(typeof(Func<FieldInfo,bool>), "enumNamePredicate");
    	
    	var body = Expression.Call(method, collectionParameter, enumNamePredicateParameter);
    	
    	var lambda = Expression.Lambda<Func<IEnumerable<FieldInfo>, Func<FieldInfo, bool>, FieldInfo>>(body, collectionParameter, enumNamePredicateParameter);
    	var f = lambda.Compile();
    	
    	Console.WriteLine(f(typeof(Apple).GetFields(), fi => fi.Name == "color").Name);
    }
    
    class Apple
    {
    	public string color;
    }

    public class StoredFunctionAccessorAttribute : LinqToDB.Sql.FunctionAttribute
    {
    	public StoredFunctionAccessorAttribute()
    	{
    		base.ServerSideOnly = true;
    	}
    
    	// don't call these properties, they are made private because user of the attribute must not change them
    	// call base.* if you ever need to access them
    	private new bool ServerSideOnly { get; set; }
    	private new int[] ArgIndices { get; set; }
    	private new string Name { get; set; }
    	private new bool PreferServerSide { get; set; }
    
    	public override ISqlExpression GetExpression(System.Reflection.MemberInfo member, params ISqlExpression[] args)
    	{
    		if (args == null)
    			throw new ArgumentNullException("args");
    
    		if (args.Length == 0)
    		{
    			throw new ArgumentException(
    				"The args array must have at least one member (that is a stored function name).");
    		}
    
    		if (!(args[0] is SqlValue))
    			throw new ArgumentException("First element of the 'args' argument must be of SqlValue type.");
    
    		return new SqlFunction(
    			member.GetMemberType(),
    			((SqlValue)args[0]).Value.ToString(),
    			args.Skip(1).ToArray());
    	}
    }
    
    public static class Sql
    {
    	private const string _serverSideOnlyErrorMsg = "The 'StoredFunction' is server side only function.";
    
    	[StoredFunctionAccessor]
    	public static TResult StoredFunction<TResult>(string functionName)
    	{
    		throw new InvalidOperationException(_serverSideOnlyErrorMsg);
    	}
    
    	[StoredFunctionAccessor]
    	public static TResult StoredFunction<TParameter, TResult>(string functionName, TParameter parameter)
    	{
    		throw new InvalidOperationException(_serverSideOnlyErrorMsg);
    	}
    }
    
    ...
    
    [Test]
    public void Test()
    {
    	using (var db = new TestDb())
    	{
    		var q = db.Customers.Select(c => Sql.StoredFunction<string, int>("Len", c.Name));
    		var l = q.ToList();
    	}
    }

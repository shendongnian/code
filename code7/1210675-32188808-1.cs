    void Main()
    {
    	GetPropertyName<Foo, string>(f => f.Bar);
    	GetPropertyName<Foo, string>(f => f.bar);
    }
    
    // Define other methods and classes here
    public static string GetPropertyName<T, TReturn>(Expression<Func<T, TReturn>> expression)
    {
    	expression.Dump();
    
    	MemberExpression body = (MemberExpression)expression.Body;
    	return body.Member.Name;
    }
    
    public class Foo
    {
    	public string Bar { get; set; }
    	public string bar;
    }

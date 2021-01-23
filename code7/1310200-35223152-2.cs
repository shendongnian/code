    using System;
    using System.Linq.Expressions;
    
    public class Program
    {
    	public static Delegate DumpValue<T>(Expression<Func<T>> expr)
    	{
    		MemberExpression memberExpression = expr.Body as MemberExpression;
    		
    		return expr.Compile();
    	}
    
    	public static void Main()
    	{
    		string a = "foo";
    		string b = "bar";
    		
    		var del1 = DumpValue(() => a);
    		var del2 = DumpValue(() => b);
    		
            // FALSE
    		Console.WriteLine(Object.ReferenceEquals(del1, del2));
    	}
    }

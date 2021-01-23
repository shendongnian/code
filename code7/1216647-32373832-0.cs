	using System;
	using System.Linq.Expressions;
	public class Program
	{
	    public static void Main(string[] args)
	    {
	        Target target = new Target();
	        Source source = new Source()
	        {
	            NestedField = new NestedSource()
	            {
	                Dummy = "Hello world"
	            }
	        };
	            
	        var action = Map<Source, Target>(p => p.NestedField.Dummy, x => x.TargetName);
	        action(source, target);
	        Console.WriteLine(target.TargetName);
	    }
	    public static Action<TSource, TTarget> Map<TSource, TTarget>(Expression<Func<TSource, object>> getter, Expression<Func<TTarget, object>> setter)
	    {
	        var sourceField = getter.Body as MemberExpression;
	        var targetField = setter.Body as MemberExpression;
			
			// here we create new assign expression
	        var assign = Expression.Assign(targetField, sourceField);
			// and then compile it with original two parameters
	        var lambda = Expression.Lambda<Action<TSource, TTarget>>(assign, getter.Parameters[0], setter.Parameters[0]);
	        return lambda.Compile();
	    }
	}
	public class Target
	{
	    public string TargetName { get; set; }
	}
	public class NestedSource
	{
	    public string Dummy { get; set; }
	}
	public class Source
	{
	    public NestedSource NestedField { get; set; }
	}

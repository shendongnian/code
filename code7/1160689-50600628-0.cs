    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public class Program
    {
    	public static void Main()
	    {
    		IQueryable<string> p = Enumerable.Empty<string>().AsQueryable();
            p = p.Where(pp => pp[0] == 'A');
            p = p.Skip(2).Take(4);
            p = p.OrderBy(pp => pp.Length);
	    	var vv = new[] {"Afss", "Acv", "Adfv", "Bcvx", "Ng"}.AsQueryable();
		    // Filtering of the vv collection with expression from p 
		    var expr = ExpressionTreeConstantReplacer.CopyAndReplace(p.Expression, typeof(EnumerableQuery<string>), vv);
    		var filteredResult = vv.Provider.CreateQuery<string>(expr);
		
	    	Console.Write("Source: \t");
		    foreach(var temp in vv)
			    Console.Write("{0} ", temp);
		
	    	Console.WriteLine();
		
		    Console.Write("Filtered: ");
		    foreach(var temp in filteredResult)
			    Console.WriteLine(temp);
	    }
	
	    class ExpressionTreeConstantReplacer<T> : ExpressionVisitor
	    {
    		Type originalType;
    		T replacementConstant;
    		internal ExpressionTreeConstantReplacer(Type originalType, T replacementConstant)
    		{
    			this.originalType = originalType;
    			this.replacementConstant = replacementConstant;
    		}
		    protected override Expression VisitConstant(ConstantExpression c)
		    {
	    		return c.Type == originalType ? Expression.Constant(replacementConstant) : c;
		    }
    	}
	    class ExpressionTreeConstantReplacer
	    {
	    	internal static Expression CopyAndReplace<T>(Expression expression, Type originalType, T replacementConstant)
		    {
	    		var modifier = new ExpressionTreeConstantReplacer<T>(originalType, replacementConstant);
	    		return modifier.Visit(expression);
    		}
    	}
    }

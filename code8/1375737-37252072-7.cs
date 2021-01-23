    public enum BooleanGreed
    {
    	Greedy = 0,
    	LazyFalse,
    	LazyTrue
    }
    
    public interface IBooleanConnective
    {
    	bool Operator(bool left, bool right);
    	
    	BooleanGreed Greed { get; }
    }
    
    public sealed class BooleanConnective : IBooleanConnective
    {
    	private BooleanConnective(
    		Func<bool, bool, bool> @operator,
    		BooleanGreed greed)
    	{
    		this.OperatorFunction = @operator;
    		this.Greed = greed;
    	}
    	
    	public static IBooleanConnective AndAlso { get; } =
            new BooleanConnective(
                (left, right) => left && right,
                BooleanGreed.LazyFalse);
    	
    	public static IBooleanConnective OrElse { get; } =
            new BooleanConnective(
                (left, right) => left || right,
                BooleanGreed.LazyTrue);
    	
    	public BooleanGreed Greed { get; }
    	
    	private Func<bool, bool, bool> OperatorFunction { get; }
    	
    	public bool Operator(bool left, bool right)
    	{
    		return this.OperatorFunction(left, right);	
    	}
    }
    
    public static class Ext
    {
    	public static IEnumerable<T> Apply<T>(
    		this IEnumerable<T> source,
    		IBooleanConnective connective,
    		params Predicate<T>[] predicates)
    	{
    		return source.Where(t => MergePredicates(t, predicates, connective));
    	}
    							
    	private static bool MergePredicates<T>(
                T t,
                IEnumerable<Predicate<T>> predicates,
                IBooleanConnective connective)
    	{
    		var e = predicates.GetEnumerator();
    		if (!e.MoveNext())
    		{
    			return false;
    		}
    		
    		var value = e.Current(t);
    		switch (connective.Greed)
    		{
    			case BooleanGreed.Greedy:
    				break;
    			
    			case BooleanGreed.LazyFalse:
    				if (!value)
    				{
    					return false;
    				}
    			
    				break;
    			
    			default:
    				if (value)
    				{
    					return true;	
    				}
    			
    				break;
    		}
    		
    		while (e.MoveNext())
    		{
    			value = connective.Operator(value, e.Current(t));
    			switch (connective.Greed)
    			{
    				case BooleanGreed.Greedy:
    					break;
    				
    				case BooleanGreed.LazyFalse:
    					if (!value)
    					{
    						return false;
    					}
    				
    					break;
    				
    				default:
    					if (value)
    					{
    						return true;	
    					}
    				
    					break;
    			}
    		}
    		
    		return value;
    	}
    							
    }

    public abstract class BaseComparable<TLeft, TRight>
    {
    	public static readonly Func<TLeft, BaseComparable<TLeft, TRight>> Factory = CreateFactory();
    	private static Func<TLeft, BaseComparable<TLeft, TRight>> CreateFactory()
    	{
    		Type genericTypeDefinition;
    		if (typeof(IComparable<TRight>).IsAssignableFrom(typeof(TLeft)))
    			genericTypeDefinition = typeof(LeftComparable<,>);
    		else if (typeof(IComparable<TLeft>).IsAssignableFrom(typeof(TRight)))
    			genericTypeDefinition = typeof(RightComparable<,>);
    		else
    			throw new ArgumentException();
    		var parameter = Expression.Parameter(typeof(TLeft), "value");
    		var body = Expression.New(genericTypeDefinition
    			.MakeGenericType(typeof(TLeft), typeof(TRight))
    			.GetConstructor(new[] { typeof(TLeft) }), parameter);
    		var lambda = Expression.Lambda<Func<TLeft, BaseComparable<TLeft, TRight>>>(body, parameter);
    		return lambda.Compile();
    	}
    }
    public static class BaseComparable
    {
    	public static BaseComparable<TLeft, TRight> AsComparableFor<TLeft, TRight>(this TLeft left, TRight right)
    	{
    		return BaseComparable<TLeft, TRight>.Factory(left);
    	}
    }

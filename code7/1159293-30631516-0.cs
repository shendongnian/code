    public static class Extensions
    {
    	public static IEnumerable<TSource> WrapAsEnumerable<TSource>(this object source)
    	{
    		var allInterfaces = source.GetType().GetInterfaces();
    		
    		IEnumerable<Type> allEnumerableInterfaces = allInterfaces.Where(t => t.Name.StartsWith("IEnumerable"));
    		if (!allEnumerableInterfaces.Any())
    			return new[] { (TSource)source };
    		IEnumerable<Type> genericEnumerableOfTSource = allEnumerableInterfaces.Where(t => t.GenericTypeArguments.Contains(typeof(TSource)));
    		// we have a generic implementation
    		if (genericEnumerableOfTSource.Any())
    		{
    			return (IEnumerable<TSource>) source;
    		}
    		return new[] { (TSource)source }; ;
    	}
    }
    [TestFixture]
    public class Tests
    {
    	[Test]
    	public void should_return_string_an_enumerable()
    	{
    		const string aString = "Hello World";
    		var wrapped = aString.WrapAsEnumerable<string>();
    		wrapped.ShouldAllBeEquivalentTo(new[] {"Hello World"});
    	}
    	[Test]
    	public void should_return_generic_enumerable_unwrapped()
    	{
    		var aStringList = new List<string> { "Hello", "World" };
    		var wrapped = aStringList.WrapAsEnumerable<string>();
    		wrapped.ShouldAllBeEquivalentTo(new[] { "Hello", "World" });
    	}
    	[Test]
    	public void should_return_non_generic_enumerable_unwrapped()
    	{
    		var aStringArray = new[] {"Hello", "World"};
    		var wrapped = aStringArray.WrapAsEnumerable<string>();
    		wrapped.ShouldAllBeEquivalentTo(new[] { "Hello", "World" });
    	}
    }

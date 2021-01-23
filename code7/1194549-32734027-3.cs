	public class Foo
	{
	}
	public static class Ex
	{
		public static IColumn Select<TResult>(this IColumn source, Func<object, TResult> selector)
		{
			throw new NotImplementedException();
		}
	}
	
	public interface IColumn { }

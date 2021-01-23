	public class Program
	{
		public static void Main(string[] args)
		{
			Expression<Func<Entity, string>> parent = (y) => y.SearchColumn;
			Expression<Func<Entity, string>> sub = (y) => y.Sub.SearchColumn;
			var result = Wrap(parent);
			Console.WriteLine(result);
			result = Wrap(sub);
			Console.WriteLine(result);
			result = Wrap<Entity>((y) => y.Sub.Sub.Sub.SearchColumn);
			Console.WriteLine(result);
		}
		private static object Wrap<T>(Expression<Func<T, string>> accessor)
		{
			var stringContains = typeof (String).GetMethod("Contains", new[] {typeof (String)});
			var pe = Expression.Parameter(typeof (T), "__x4326");
			var call = Expression.Call(
				accessor.Body,
				stringContains,
				Expression.Constant("foo")
				);
			return Expression.Lambda<Func<Entity, bool>>(call, pe);
		}
	}
	public class Entity
	{
		public string SearchColumn { get; set; }
		public Entity Sub { get; set; }
	}

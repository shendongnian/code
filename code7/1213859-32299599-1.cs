    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace Tests
    {
    	public static class Utils
    	{
    		public static Func<TInput, TOutput> CreateMapFunc<TInput, TOutput>()
    		{
    			var source = Expression.Parameter(typeof(TInput), "source");
    			var body = Expression.MemberInit(Expression.New(typeof(TOutput)),
    				source.Type.GetProperties().Select(p => Expression.Bind(typeof(TOutput).GetProperty(p.Name), Expression.Property(source, p))));
    			var expr = Expression.Lambda<Func<TInput, TOutput>>(body, source);
    			return expr.Compile();
    		}
    	}
    	public static class MapFunc<TInput, TOutput>
    	{
    		public static readonly Func<TInput, TOutput> Instance = Utils.CreateMapFunc<TInput, TOutput>();
    	}
    	public struct Unit<T>
    	{
    		public readonly T Value;
    		public Unit(T value) { Value = value; }
    		public U MapTo<U>() { return MapFunc<T, U>.Instance(Value); }
    	}
    	public static class Extensions
    	{
    		public static Unit<T> Unit<T>(this T source) { return new Unit<T>(source); }
    	}
    	// Test
    	public class Foo
    	{
    		public string Bar { get; set; }
    		public string Baz { get; set; }
    	}
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var obj = new { Bar = "My Name", Baz = "Some other data" };
    			//var foo = new Foo { Bar = obj.Bar, Baz = obj.Baz };
    			var foo = obj.Unit().MapTo<Foo>();
    		}
    	}
    }

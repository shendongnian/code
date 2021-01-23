    public class Program
    {
    	public static void Main()
    	{
    		var x = new MyClass<Bar>();
    		FooDelegate test = x.Foo;
    		test("Do It");
    	}
    	public delegate IBar FooDelegate(string str);
    	public interface IBar { }
    	public class Bar : IBar { }
    	public class MyClass<T> where T : IBar, new()
    	{
    		T item;
    		public T Foo(string input) { Console.WriteLine(input); return item; }
    	}
    }

	abstract class Base<T>
	where T : Base<T>
	{
		private static HashSet<string> values = new HashSet<string>();
		internal Base(string value)
		{
			if (Base<T>.values.Contains(value))
				throw new Exception("Not unique");
			else
				Base<T>.values.Add(value);
		}
		public static string GetClassName()
		{
			return typeof(T).Name;
		}
		public static IEnumerable<string> GetValues()
		{
			return new LinkedList<string>(Base<T>.values);
		}
	}
	class A : Base<A>
	{
		public A(string value) : base(value) { }
	}
	class B : Base<B>
	{
		public B(string value) : base(value) { }
	}
	static void Main(string[] args)
	{
		var a1 = new A("value");
		var a2 = new A("value 2");
		// var a3 = new A("value"); // Would throw an exception
		var b = new B("value"); // Does not throw an exception
		Console.WriteLine(A.GetClassName()); // Prints "A"
		Console.WriteLine(B.GetClassName()); // Prints "B"
		Console.WriteLine("The values in A:");
		foreach (var value in A.GetValues()) // This loop prints "value" and "value 2"
		{
			Console.WriteLine("\t" + value);
		}
		Console.WriteLine("The values in B:");
		foreach (var value in B.GetValues()) // This loop prints "value"
		{
			Console.WriteLine("\t" + value);
		}
	}

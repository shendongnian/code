	[DebuggerDisplay("{ToString()}")]
	class Class1
	{
		public string Test;
		public override string ToString()
		{
			return "Test=" + Test;
		}
	}
	[DebuggerDisplay("{ToString()}")]
	class Class2
	{
		public Class1 obj;
		public override string ToString()
		{
			return "obj=" + obj;
		}
	}
	internal class Program
	{
		public static void Main(string[] args)
		{
			var c1 = new Class1() {Test = "test"};
			var c2 = new Class2() {obj = c1};
		}
	}

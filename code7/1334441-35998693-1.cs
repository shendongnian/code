	public class Program
	{
		public static void Main()
		{
			var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			Console.WriteLine(typeof(B).GetFields(flags).Length);
		}
	}
	public class A
	{
		private int _foo;
	}
	public class B : A
	{
		private int _bar;
	}
	

	public class Program
	{
		public static void Main()
		{
			Console.WriteLine(typeof(B).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length);
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
	

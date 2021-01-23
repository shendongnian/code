	public class A
	{
		public A(string a)
		{
			Console.WriteLine(a);
		}
		public A(int a)
		{
			Console.WriteLine(a * a);
		}
	}
	public class B : A
	{
		public B(string a): base (a)
		{
		}
		public B(int a): this (a.ToString())
		{
		}
	}

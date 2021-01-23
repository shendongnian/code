	public class A
	{
		public int Modify()
		{
			return 1;
		}
	}
	public class B : A
	{
		public new int Modify()
		{
			return 2;
		}
	}
	public class C : B
	{
		public new int Modify()
		{
			return ((A)this).Modify();
		}
	}
	
	public void Main()
	{
		dynamic obj = new C();
		Conosle.WriteLine(c.Modify());
	}

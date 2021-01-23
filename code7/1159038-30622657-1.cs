	public class A
	{
		public string Foo { get; protected set; }
		
		public A()
		{
			Foo = "A";
		}
	}
	
	public class B : A
	{
		public B()
			: base()
		{
			Foo = "B";
		}
	}

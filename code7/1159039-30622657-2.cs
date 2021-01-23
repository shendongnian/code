	public class A
	{
		protected string FooField;
		public string Foo { get { return FooField; } }
		
		public A()
		{
			FooField = "A";
		}
	}
	
	public class B : A
	{
		public B()
			: base()
		{
			FooField = "B";
		}
	}

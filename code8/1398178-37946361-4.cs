	public class A
	{
	   public int MyProperty {get; set;}
	}
	public class B : A
	{
		public B()
			: A() 
		{
			MyProperty = 1;
		}
	}

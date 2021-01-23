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
	Or use this other approach
	public class B
	{
		private static _a;
		public class A
		{
			public int MyProperty {get; set;}
		}
		
		public static A AA {
			if (_a == null) {
				_a = new A();
			}
			
			return _a;
		}  
	}
	This implmentation will return
	B.A.MyProperty.ToString();
	public class C
	{
	   System.ConsoleWriteLine(B.A.MyProperty.ToString());  //How to handle this?  
	}
		

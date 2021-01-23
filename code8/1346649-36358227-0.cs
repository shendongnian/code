	public class MyClass
	{
		public Base1 Base1 { get; set; }
		public Base2 Base2 { get; set; }
	}
	
	public class Base1
	{
	    public void m1() { }
	}
	
	public class Base2
	{
	    public void m2() { }
	}
	// use like
	myClass.Base1.m1();

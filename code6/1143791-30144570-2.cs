	public class MyClass 
	{
		public int MyInt { get; set; }
	}
	
	public static void Main()
	{
		
		MyClass myclass = new MyClass();
		myclass.MyInt = 5;
		
		Console.WriteLine(myclass.MyInt);
		ChangeMe(myClass);
		Console.WriteLine(myclass.MyInt);
	}
	
	public static void ChangeMe(MyClass i)
	{
		i.MyInt = 7;
	}
    // Outputs:
    // 5
    // 7

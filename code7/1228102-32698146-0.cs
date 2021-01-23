    void Main()
    {
    	var methodFromJson = "MyMethod";
    	typeof(MyClass).GetMethod(methodFromJson).Invoke(null, new object [] { 42 });
    }
    
    public class MyClass
    {
    	public static void MyMethod(int x)
    	{
    		Console.WriteLine(string.Format("MyMethod. Parameter: {0}", x));
    	}
    }

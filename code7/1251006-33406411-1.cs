    void Main()
    {
    	var obj = new Something();
    	var methods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public 
                                          | BindingFlags.DeclaredOnly | BindingFlags.Static);
    	foreach (var method in methods)
    	{
    		method.Invoke(obj, null);
    	}
    }
    
    public class Something {
    	public void TestA() { Console.WriteLine("Running A"); }
    	public void TestB() { Console.WriteLine("Running B"); }
    	public void TestC() { Console.WriteLine("Running C"); }
    	public void TestD() { Console.WriteLine("Running D"); }
    	public static void TestE() { Console.WriteLine("Running E"); }
    }

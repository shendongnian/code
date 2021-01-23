    class Program 
    {
    	public static void f(ref int num)
    	{
    		num++;
    	}
    	
    	private static void Main(string[] args)
    	{
    		int a = 0;
    		f(ref a); // is the same as: Program.f(ref a)
    		Console.WriteLine(a);
    		Console.Read();
    	}
    }

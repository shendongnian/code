    class Program 
    {
    	public void f(ref int num)
    	{
    		num++;
    	}
    	
    	private static void Main(string[] args)
    	{
    		int a = 0;
            var p = new Program();
    		p.f(ref a);
    		Console.WriteLine(a);
    		Console.Read();
    	}
    }

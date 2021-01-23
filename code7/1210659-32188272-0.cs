    static void masodmegold(double a, double b, double c)
    {
    	double x0, x1, x2;
    	double gyokalatt = b * b - 4 * a * c;
    	if (a == 0)
    	{
    		Console.WriteLine("i want to write some text out here");
    		Console.WriteLine("double.NaN");
    	}
    	else
    	{
    		if (gyokalatt > 0)
    		{
    			// i cant return two values
    			// while you can't reutnr twice, you can just print them out directly
    			Console.WriteLine((-b + Math.Sqrt(gyokalatt)) / (2 * a));
    			Console.WriteLine((-b - Math.Sqrt(gyokalatt)) / (2 * a));
    		}
    		else if (gyokalatt == 0)
    		{
    			Console.WriteLine(-b / (2 * a));
    		}
    		else
    		{
    			Console.WriteLine("i also want some text here");
    			Console.WriteLine("double.NaN");
    		}
    	}
    }
    static void Main(string[] args)
    {
    	masodmegold(1, 4, 3);
    	Console.ReadKey();
    }

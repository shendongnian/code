    public static void PrintPyramid(int n)
	{
	    var i = 0;
	    while (n > 0)
	    {
	        Console.Write(++i);
	        if (IsTriangularNumber(i))
	        {
	            Console.Write(Environment.NewLine);
	            n--;
	        }
	        else
	        {
	            Console.Write(" ");
	        }
	    }
	}
	public static bool IsTriangularNumber(int i)
	{
	    var n = (int)Math.Sqrt(i*2);
	    return n*(n + 1) / 2 == i;
	}

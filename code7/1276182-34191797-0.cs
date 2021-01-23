	public static void Main()
	{
		ulong ul = ulong.MaxValue; 
        long l = (long)ul;
        var s = Convert.ToString(l, 8); //8 => oct, 2 => bin
		Console.WriteLine(s); //Outputs 1777777777777777777777
	}

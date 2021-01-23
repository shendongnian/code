	static void Main(string[] args)
    {
        int[] values = new int[3];
		for (int i = 1; i <= 3; i++)
		{
			Console.WriteLine("Please enter side " + i +" value");  
			values[i - 1] = Int32.Parse(Console.ReadLine());
		}
		
		Triangle triangle = new Triangle(values[0], values[1], values[2]);
		Console.WriteLine(triangle.TriangleType);
		Console.WriteLine();
	}

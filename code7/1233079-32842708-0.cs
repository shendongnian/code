    Console.WriteLine("Please enter the number of triangles in your tree: ");
    int n = int.Parse(Console.ReadLine());
    
    for (int i = 1; i <= n; i++)
    {
    	for (int j = 0; j < i; j++)
    	{
    		string branch = new String('*', j);
    		Console.WriteLine(branch.PadLeft(n + 3) + "*" + branch);
    	}
    }

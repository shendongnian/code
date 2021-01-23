	public static void Main()
	{
         int[,] grid = new int[4,5] { { 1, 2, 4,  5,  6 }, //how to get largest number of each row
                                      { 3, 4, 7,  8,  9 }, 
                                      { 5, 6, 56, 12, 45 }, 
                                      { 7, 8, 45, 12, 78 }};
		
		int w=grid.GetLength(0), h=grid.GetLength(1);
		Console.WriteLine(string.Join(",",
			Enumerable.Range(0,w).Select(i=>Enumerable.Range(0,h).Select(j=>grid[i,j]).Max())));
	}

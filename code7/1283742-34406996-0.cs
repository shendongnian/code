    var ints = new List<int>() { 66, 7, 9, -5, -22, 67, 122, -333, 555, -2 };
    var ordered = ints.OrderBy(x =>
    {
    	x = Math.Abs(x);
    
    	Console.WriteLine($"Getting length of {x}");
    
    	int len = 0;
    	while (x >= 1)
    	{
    		len++;
    		x /= 10;
    	}
    	return len;
    }).ToList();
    
    Console.WriteLine("After OrderBy");
    Console.WriteLine("Fetching first item in ordered sequence");
    Console.WriteLine($"First item is {ordered.First()}");
    Console.WriteLine(string.Join(" ", ordered));

	int[] arr = new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 }; 
	int rank =2; 
	var item = arr.GroupBy(x=>x)          // Group them
	   .OrderByDescending(x=>x.Count())   // Sort based on number of occurrences
	   .Skip(rank-1)                      // Traverse to the position
	   .FirstOrDefault();	              // Take the element
	   
	
	if(item!= null)
	{
		Console.WriteLine(item.Key);
        // output - 3
	}

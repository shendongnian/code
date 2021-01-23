        int[,]  numbers = new int[3,5]
		{
			{1, 4,5,6, 10}, 
			{1,-2,3, 10, 1, }, 
			{-7,-8,-9, -1, 0}
		};
				
	
		var row_sum  = numbers.Cast<int>()		
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / (numbers.GetUpperBound(1) +1))
		.Select(x => x.OrderBy(c=>c.Value).Skip(1).Take(numbers.GetUpperBound(1)-1).Sum(c=>c.Value))
		.ToArray();	

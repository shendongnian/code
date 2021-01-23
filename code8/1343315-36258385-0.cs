		int[][]  numbers2 = new int[][]
		{
			new int[] {1, 4,5,6, 10}, 
			new int[] {1,-2,3, 10, 1, }, 
			new int[] {-7,-8,-9, -1, 0}
		};
		
		var sum_array =numbers2.Select(x => x.OrderBy(c=>c)
						      				 .Skip(1)
						      				 .Take(x.Length-2)
						      				 .Sum(c=>c)		
									  );

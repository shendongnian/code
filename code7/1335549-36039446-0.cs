        object[,] array = new object[,] 
			{ 
				{"columnHeader1", 1, 2, 3},
				{"columnHeader2", 4, 5, 6},
				{"columnHeader3", 7, 8, 9}
			};
		int i, maxI = array.GetLength(0);
		List<MyCustomObject> output = new List<MyCustomObject>();
        // 1 - plain old for		
		for(i = 0; i < maxI; i++) {
			var obj = new MyCustomObject {
				ColumnHeader = (string)array[i,0],
    			ValueOne = (int)array[i,1],
    			ValueTwo = (int)array[i,2],
    			ValueThree = (int)array[i,3]
			};
			output.Add(obj);
		}
		
		Console.WriteLine(output[0].ColumnHeader);
		Console.WriteLine(output[2].ValueThree);
		
		// 2 - just the same, with Linq. If you need streaming,
        //     linq lets you return the IEnumerable so you can
        //     do foreach on it
		output = Enumerable.Range(0, array.GetLength(0))
			.Select(idx => new MyCustomObject {
					ColumnHeader = (string)array[idx,0],
					ValueOne = (int)array[idx,1],
					ValueTwo = (int)array[idx,2],
					ValueThree = (int)array[idx,3]
				}).ToList();

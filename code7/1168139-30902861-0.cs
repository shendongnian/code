        List<string> stuff1 = new List<string>();
		List<string> stuff2 = new List<string>();
		List<string> stuff3 = new List<string>();
		List<string> otherStuff = new List<string>();
		stuff1.Add("a1");
		stuff1.Add("a2");
		stuff1.Add("a3");
		stuff1.Add("a4");
		
		stuff2.Add("b1");
		stuff2.Add("b2");
		stuff2.Add("b3");
		stuff2.Add("b4");
				
		stuff3.Add("c1");
		stuff3.Add("c2");
		stuff3.Add("c3");
		stuff3.Add("c4");
		
		otherStuff.Add("d1");
		otherStuff.Add("d2");
		
		List<List<List<string>>> first64 = new List<List<List<string>>>();
		List<List<string>> other8 = new List<List<string>>();
		foreach (var v1 in stuff1) {
			// Fill temporary 2d list.
			List<List<string>> list2d = new List<List<string>>();			
			foreach (var v2 in stuff2) {
				// Fill temporary 1d list.
				List<string> list1d = new List<string>();
				foreach(var v3 in stuff3) {
					list1d.Add(v1 + v2 + v3);
				}
				
				// Add each 1d list to the temp 2d list.
				list2d.Add(list1d);
			}
			
			// Add each 2d list to the main 3d list.
			first64.Add(list2d);
			// Create another 1d list to hold second combinations.
			List<string> otherList1d = new List<string>();
			foreach(var otherV in otherStuff) {
				otherList1d.Add(v1 + otherV);
			}
			
			// Add second 1d list to second 2d list.
			other8.Add(otherList1d);
		}
		// Print first 64.
		for(var x = 0; x < first64.Count; x++) {
			for(var y = 0; y < first64[x].Count; y++) {
				for(var z = 0; z < first64[x][y].Count; z++) {
					Console.WriteLine(first64[x][y][z]);
				}
			}
		}
		
		// Print other 8.
		for(var x = 0; x < first64.Count; x++) {
			for(var y2 = 0; y2 < other8[x].Count; y2++) {
				Console.WriteLine(other8[x][y2]);
			}
		}

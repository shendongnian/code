		List<string> list1 = new List<string>(){ "A1", "A2", "A3" };
		List<string> list2 = new List<string>() { "AA2", "B1", "B3", "AA1", "B2", "AA3" };
		
		
		var results = list2.Select(s=> 
		{
			var ind = list1.IndexOf(list1.Find(f=> s.Contains(f)));
			
			return new 
			{ 
				index= ind==-1? int.MaxValue : ind, // assign max value if item is not found to place in the end in order. 
				item =s 
			};
			
		}).OrderBy(o=>o.index).ThenBy(o=>o.item).Select(s=>s.item); 

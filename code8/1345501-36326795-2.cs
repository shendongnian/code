    var dict = new Dictionary<int, DayOfWeek>(); 
		int i=0;
		foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
		{
			dict.Add(i++,day);
		}
		
		
		List<DayOfWeek> days = new List<DayOfWeek>();
		
		i=0;
		foreach(var c in "1010101")
		{
			if(c=='1')
			{
				days.Add(dict[i]);
			}
			i++;
		}
		
		string.Join(",",days).Dump();

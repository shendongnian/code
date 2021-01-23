		var list = new List<double> { 2.1, 2.2, 4, 4.1, 8, 8.2};
		var avereges = new List<double>();
		
		
		list.Sort();
		
		
		double sum = list[0], original = list[0], count = 1;
		
		
		for (int i = 1; i < list.Count; i++)
		{
            var isSimiliar = Math.Abs(original-list[i]) < 0.25;
			
			if (isSimiliar)
			{
				sum += list[i];
				count++;
			}
			
			if (!isSimiliar || i == list.Count-1)
			{
				avereges.Add(sum/count);
				count = 1;
				sum = list[i];
				original = list[i];
			}
		}
		
		
		Console.WriteLine(String.Join(" ", avereges));

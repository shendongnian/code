		string input = "qwerty";
		int maxPossibilities = Convert.ToInt32(Math.Pow(2.0, input.Length));
	    List<string> allPossibilities = new List<string>();
		for(int i = 0; i < maxPossibilities; ++i) 
		{
			string result = "";
			for(int j = 0; j < input.Length; j++)
			{
				result += input[j];
				if((i & (1 << j)) != 0) { result += "."; }
			}
			
			allPossibilities.Add(result);
			System.Console.WriteLine(result);
		
		}

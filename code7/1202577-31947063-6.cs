		var match = false;
		for (var i = 0; i < arr.m; i++)
		{
			for (var q = 0; q < arr.m; q++)
			{
				if (a[i].Length != b[q].Length)
				{
					continue;
				}
				
				match = true;
				for (var j = 0; j < a[i].Length; j++)
				{
					if (a[i][j] != b[q][j])
					{
						match = false;
						break;
					}
				}
				
				if (match)
				{
					break;
				}
			}
			
			if (!match)
			{
				break;
			}
		}
		
		if (!match)
		{
			Console.WriteLine("two graphs are different.");
		}

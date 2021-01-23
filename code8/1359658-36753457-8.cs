	public static void Main()
	{		
		var possibleChoices = Choose(5);
		
		foreach (var choice in possibleChoices) {
			Console.Out.WriteLine(string.Join(", ", choice));
		}
	}
	
	public static IEnumerable<IEnumerable<int>> Choose(int max) 
	{		
		var remaining = Enumerable.Range(0, max); 
		
		return ChooseRecursive(remaining, Enumerable.Empty<int>());
	}
	
	public static IEnumerable<IEnumerable<int>> ChooseRecursive(IEnumerable<int> remaining, IEnumerable<int> chosen) 
	{		
		yield return chosen;
		
		foreach (var digit in remaining) 
		{
			var choices = ChooseRecursive(
				remaining.Where(d => d > digit), 
				chosen.Concat(new [] { digit })
			);
			foreach (var choice in choices)
			{					
				yield return choice;
			}
		}
	}

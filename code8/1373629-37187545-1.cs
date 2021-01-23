	static void Main()
	{
		var wordLists = new List<string[]>()
		{
			new string[] { "bear", "chicken", "tuna" },
			new string[] { "claw", null, "salad" },
			null,
			new string[] { "donut", "salad", null },
		};
	
		foreach (var result in AllPermutations(wordLists)) 
		{
			System.Console.WriteLine(string.Join(",", result));
		}
	}
	// our recursive function. 
	private static IEnumerable<IEnumerable<string>> AllPermutations(IEnumerable<IEnumerable<string>> wordLists, int index = 0, List<string> current = null)
	{
		if (current == null) 
		{
			current = new List<string>();
		}
		
	    if (index == wordLists.Count()) 
		{ // the end condtion. it is reached when we are past the last list
			yield return current;
	    }
		else
		{ // if we are not at the end yet, loop through the entire list
		  // of words, appending each one, then recursively combining
		  // the other lists, and finally removing the word again.
		    var wordList = wordLists.ElementAt(index);
			if (wordList != null)
			{
				foreach (var word in wordList)
				{
					if (word == null) continue;
					current.Add(word);
					foreach (var result in AllPermutations(wordLists, index + 1, current)) 
					{
						yield return current;
					}
					current.RemoveAt(current.Count - 1);
				}
			}
			else
			{
				foreach (var result in AllPermutations(wordLists, index + 1, current)) 
				{
					yield return current;
				}
			}
		}
	}

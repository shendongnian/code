    public static void Main()
	{
        var words = new List<WordForm>();
				words.Add(new WordForm { WordId = "Apple" });
		words.Add(new WordForm { WordId = "Banana" });
		words.Add(new WordForm { WordId = "Cake" });
		words.Add(new WordForm { WordId = "Date" });
		words.Add(new WordForm { WordId = "Egg" });
		
		var filterChars = new string[] { "C", "D" };
		var filtered = GetStartingWith(filterChars, words);
		
		foreach (var item in filtered)
		{
		   Console.WriteLine(item.WordId);
		}
			
	}
	public static List<WordForm> GetStartingWith(string[] startingLetters, List<WordForm> collection)
	{
		var returnList = new List<WordForm>();
		
		foreach (var wordForm in collection)
		{
			foreach (var startingLetter in startingLetters)
			{
				if (wordForm.WordId.StartsWith(startingLetter))
				{
				    returnList.Add(wordForm);
				}
			}
		}
		
		return returnList;
	}
	public class WordForm
	{
		public string WordId { get;	set; }
        //... Plus all your other properties on WordForm...
	}

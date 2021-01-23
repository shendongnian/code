	var myText = new []
	{
		"My name is Orel Eraki and i love snooker",
		"I also enjoy Hiking and visiting different cultures."
	};
	const string vowels = "aeiou";
	int minVowelsPerLine = 3;
	int minVowelsPerWord = 2;
	int numberOfLinesWithMoreThanXVowels = 0;
	foreach (var line in myText)
	{
		// Lowering entire line, to simplify the equality check.
		string workingLine = line.ToLower();
		// Splitting words into array for working on each word in array separately.
		var wordsInALine = workingLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		// Counting the characters on each word if they appears(contains) in the 'vowels' array
		// and eventually seeing if the number of each 'vowles' in word is at least 'minVowelsPerWord' amount.
		int numberOfWordsWithAtLeastXVowels = wordsInALine.Count(word => word.ToLower().Count(c => vowels.Contains(c)) > minVowelsPerWord);
		// Counting the entire 'vowles' inside a line.
		int numberOfVowlesInLine = workingLine.Count(c => vowels.Contains(c));
		if (numberOfVowlesInLine > minVowelsPerLine)
		{
			numberOfLinesWithMoreThanXVowels++;
		}
		Console.WriteLine("Line[{0}] has {1} words with at least {2} vowles in them.", line, numberOfLinesWithMoreThanXVowels, minVowelsPerWord);
	}
	Console.WriteLine("Text has {0} lines with at least {1} vowles in them.", numberOfLinesWithMoreThanXVowels, minVowelsPerLine);

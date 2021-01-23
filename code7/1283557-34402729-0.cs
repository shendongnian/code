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
		var wordsInALine = line.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		int numberOfWordsWithAtLeastXVowels = wordsInALine.Count(word => word.Count(c => vowels.Contains(c)) > minVowelsPerWord);
		int numberOfVowlesInLine = line.ToLower().Count(c => vowels.Contains(c));
		if (numberOfVowlesInLine > minVowelsPerLine)
		{
			numberOfLinesWithMoreThanXVowels++;
		}
		Console.WriteLine("Line[{0}] has {1} words with at least {2} vowles in them.", line, numberOfLinesWithMoreThanXVowels, minVowelsPerWord);
	}
	Console.WriteLine("Text has {0} lines with at least {1} vowles in them.", numberOfLinesWithMoreThanXVowels, minVowelsPerLine);

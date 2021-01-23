	if (s2 == 2) //2. Count the word in a paragraph
	{
		string senttence2;
		List<string> sentences = new List<string>();
		Console.WriteLine("Enter several sentences, when done entering" +
							" sentences, use q by itself on the last line:");
		senttence2 = Console.ReadLine();
		while (senttence2 != "q")
		{
			sentences.Add(senttence2);
			senttence2 = Console.ReadLine();
		}
		Console.WriteLine("There are " + GetWordCount(sentences) + " words in that text");
	}

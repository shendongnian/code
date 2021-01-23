    String line = "qwerty/asdfg/xxx/zxcvb";
	string[] words = line.Split('/');
	string previous = words.First();
	string next = "";
	
	foreach (string word in words)
	{
		var currentIndex = (Array.IndexOf(words, word));
		if (currentIndex + 1  < words.Length)
		{
			next = words[currentIndex + 1];
		}
	
    	if (word.IndexOf("xxx", StringComparison.CurrentCulture) > -1)
    	{
        	Console.WriteLine(previous);
			
			if (next == word) 
			{
				Console.WriteLine("The match was the last word and no next word is available.");
			}
			else 
			{
				Console.WriteLine(next);
			}
    	}
		else 
		{
			previous = word;
		}
	}

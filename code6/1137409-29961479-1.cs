    Dictionary<string, int> wordsAndNumbers = new Dictionary<string, int>();
    foreach (string word in words)
    {
        if (wordsAndNumbers.ContainsKey(word.ToLower()))
            wordsAndNumbers[word.ToLower()]++;
        else
        {
            wordsAndNumbers.Add(word.ToLower(), 1);
        }
     }

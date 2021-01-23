    string input = "word3 word2";
    string[] array = 
    {
        "word1 word2 word3 word4 word5",
        "word1 word2",
        "word4 word5",
        "word1 word4 word5"
    };
    string pattern = input.Replace(" ", "|");
    List<string> results = array.Where(a => Regex.Match(a, pattern).Success).ToList();
    results.ForEach(Console.WriteLine);

    Dictionary<string, int> wordDict = new Dictionary<string, int> {
        { "Java", 0 },
        { "CSharp", 0 },
        { "OO", 0 },
        { "and", 0 },
        { "mvc", 0 }
    };
    
    string text = "Both CSharp and Java have mvc frameworks and are OO languages."
    string[] split = text.Split(' ');
    foreach(string s in split)
    {
        if (wordDict.ContainsKey(s)) {
            wordDict[s] = wordDict[s] + 1;
        }
    }

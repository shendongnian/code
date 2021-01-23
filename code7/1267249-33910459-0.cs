    string s1 = "let's play football";
    string s2 = "let's paly fotbal and cricket";
    if (s1 != s2)
    {
        var str1Parts = s1.Split(' ');
        var str2Parts = s2.Split(' ');
        var wrongOrExtraWords = str2Parts.Where(s => !str1Parts.Contains(s)).ToList();
        Console.WriteLine("Wrong words: ({0})", wrongOrExtraWords.Count());
        foreach (var str2 in wrongOrExtraWords)
        {
            Console.WriteLine(str2);
        }
    }
    else
    {
        Console.WriteLine("Both strings are equal.");
    }

    string input = File.ReadAllText("file.txt");
    foreach (string word in File.ReadLines("words.txt"))
    {
        var regex = new Regex(word, RegexOptions.IgnoreCase);
        int startat = 0;
        int count = 0;
        Match match = regex.Match(input, startat);
        while (match.Success)
        {
            count++;
            startat = match.Index + 1;
            match = regex.Match(input, startat);
        }
        Console.WriteLine(word + "\t" + count);
    }

    static void Main(string[] args)
    {
        var guessThis = "Hello";
        var letters = new HashSet<char>();
        Console.WriteLine(BuildMask(guessThis, letters));
        letters.Add('l');
        Console.WriteLine(BuildMask(guessThis, letters));
        letters.Add('H');
        Console.WriteLine(BuildMask(guessThis, letters));
    }
    static string BuildMask(string toGuess, HashSet<char> letters)
    {
        var result = new StringBuilder();
        foreach (var c in toGuess)
        {
            if (letters.Contains(c))
                result.Append(c);
            else
                result.Append('?');
        }
        return result.ToString();
    }

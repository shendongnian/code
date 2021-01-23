    private static readonly Random Rnd = new Random();
    public static string ReplaceCharactersWithRandomNumbers(string input)
    {
        return input == null ? null : string.Join("", input.ToList().Select(s => Rnd.Next(10)));
    }

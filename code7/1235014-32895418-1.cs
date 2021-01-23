    static void Main(string[] args)
    {
        const string comparisonStr = "bicyclist: \U0001F6B4, and US flag: \U0001F1FA\U0001F1F8"; //some string containing text and emoji
        var checkFor = new string[] { "1F6B4", "1F1FA-1F1F8" };
        foreach (var searchStringInHex in checkFor)
        {
            string searchString = string.Join(string.Empty, searchStringInHex.Split('-')
                                                            .Select(hex => char.ConvertFromUtf32(Convert.ToInt32(hex, 16))));
            if (comparisonStr.Contains(searchString))
            {
                Console.WriteLine($"Found {searchStringInHex}!");
            }
        }
    }

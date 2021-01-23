    static void Main(string[] args)
    {
        const string comparisonStr = "bicyclist: \U0001F6B4, and US flag: \U0001F1FA\U0001F1F8"; //some string containing text and emoji
        var checkFor = new string[] { "1F6B4", "1F1FA-1F1F8" };
        foreach (var searchString in checkFor)
        {
            StringBuilder buf = new StringBuilder();
            foreach (var hexString in searchString.Split('-'))
            {
                buf.Append(char.ConvertFromUtf32(Convert.ToInt32(hexString, 16)));
            }
            if (comparisonStr.Contains(buf.ToString()))
            {
                Console.WriteLine($"{nameof(comparisonStr)} contains {searchString}");
            }
        }
    }

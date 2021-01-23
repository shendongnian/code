    string input = YOUR_STRING_HERE;
    string pattern = @"\033";
    string[] substrings = Regex.Split(input, pattern);
    foreach (string match in substrings)
    {
       Console.WriteLine("'{0}'", match);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(RestoreNewlines("This is the end of the first paragraph.And this is the start of the second. This is the start of the third."));
        Console.WriteLine(RestoreNewlines("Example of a case.txt where it fails."));
    }
    
    private static readonly Regex PunctuationWithoutFollowingWhitespaceRegex = new Regex(@"[\.\!\?]\b");
    
    static string RestoreNewlines(string input)
    {
        return PunctuationWithoutFollowingWhitespaceRegex.Replace(input, match => match.Value + Environment.NewLine);
    }

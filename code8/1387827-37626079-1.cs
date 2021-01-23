    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FixHyperlinks("blah blah blah HYPERLINK \"http://someUrl.com\" bleh bleh bleh"));
        }
        static string FixHyperlinks(string source)
        {
            const string pattern = "HYPERLINK \"(.+)\"";
            // Get a list of all the matches in the source
            var matches = Regex.Matches(source, pattern); 
            // And get a list of all the isolated URLs extracted from the matches.
            // Group[0] is always the full match. Group[1] is our group.
            var values = (matches.Cast<Match>()
                                 .Select(m => m.Groups[1].Value)
                         ).ToList();
            // Use a Linq aggregate function to remove all of the occurences of the HYPERLINK "" wrapper around our matches.
            return values.Aggregate(source, (current, value) => current.Replace(pattern.Replace("(.+)", value), value));
        }
    }

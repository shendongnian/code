    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FixHyperlinks("blah blah blah HYPERLINK \"http://someUrl.com\" bleh bleh bleh"));
        }
        static string FixHyperlinks(string source)
        {
            const string pattern = "HYPERLINK \"(.+)\"";
            var matches = Regex.Matches(source, pattern);
            var values = (matches.Cast<Match>()
                                 .Where(m => m.Groups.Count == 2)
                                 .Select(m => m.Groups[1].Value)
                         ).ToList();
            return values.Aggregate(source, (current, value) => current.Replace(pattern.Replace("(.+)", value), value));
        }
    }

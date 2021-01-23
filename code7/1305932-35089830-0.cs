    void Main()
    {
        var lines = new[]
        {
            "Allow 10 seconds",
            "Allow 5 seconds",
            "Use 5mb"
        };
    
        var rules = new Rule[]
        {
            new Rule(
                @"^Allow\s+(?<seconds>\d+)\s+seconds?$",
                ma => AllowSeconds(int.Parse(ma.Groups["seconds"].Value)))
        };
    
        foreach (var line in lines)
        {
            bool wasMatched = rules.Any(rule => rule.Visit(line));
            if (!wasMatched)
                Console.WriteLine($"not matched: {line}");
        }
    }
    
    public void AllowSeconds(int seconds)
    {
        Console.WriteLine($"allow: {seconds} second(s)");
    }
    
    public class Rule
    {
        public Rule(string pattern, Action<Match> action)
        {
            Pattern = pattern;
            Action = action;
        }
    
        public string Pattern { get; }
        public Action<Match> Action { get; }
    
        public bool Visit(string line)
        {
            var match = Regex.Match(line, Pattern);
            if (match.Success)
                Action(match);
            return match.Success;
        }
    }

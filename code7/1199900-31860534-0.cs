    void Main()
    {
        const string Expression = @"#([^#]*)*#";
        const string TestSample = @"'#filenameid#30day#Name#.xls'";
    
        Regex regex = new Regex(Expression);
        
        regex.Matches(TestSample)
             .Cast<Match>()
             .Select(match => match.Captures[0].Value.Replace("#", ""))
             .ToList()
             .ForEach(Console.WriteLine);
    }

    void Main()
    {
        var lines = new[] { 
            "engineering design",
            "requirement engineering", 
            "reverse engineering",
            "software engineering",
            "access control policies",
            "active learning", 
            "ad hock network", 
            "agent based reasoning"
            // etc...
        };
        
        var summary = "Software engineering in 2001 - A case";
    
        var dd = new List<Tuple<String, Double, String>>();
        dd.AddRange(lines.Select(line => Tuple.Create(line, calculate_CS(line, summary), summary)));
        var top_value = dd.OrderByDescending(x => x.Item2).FirstOrDefault();
        
        var ddNew = new List<Tuple<String, Double, String>>();
        ddNew.AddRange(lines.Select(line => Tuple.Create(line, calculate_Lcs(line, summary), summary)));
        var top_value_new = ddNew.OrderByDescending(x => x.Item2).FirstOrDefault();
        
        top_value.Dump();
        top_value_new.Dump();
    }
    
    private double calculate_CS(string line, string summary)
    {
        var lineWords = line?.ToLower().Split(' ');
        var summaryWords = summary?.ToLower().Split(' ');
    
        return lineWords?.Intersect(summaryWords).Any() ?? false
            ? 0.110795817239161
            : 0;
    }
    
    private double calculate_Lcs(string line, string summary)
    {  
        // using https://www.nuget.org/packages/DuoVia.FuzzyStrings/
        return line.LongestCommonSubsequence(summary).Item2;
    }

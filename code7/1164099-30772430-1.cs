    Dictionary<string, List<string>> dictTestdata = new Dictionary<string, List<string>>
            {
                { "k1", new List<string> { "1", "Programmers" }},
                { "k2", new List<string> { "3", "Testers" }},
                { "k3", new List<string> { "", "Designers" }}, 
                { "k4", new List<string> { "", "Designers2" }}, 
            };
    		
    var query = from item in dictTestdata
    			   where String.IsNullOrWhiteSpace(item.Value.First())
    			   select item.Value.Where(v => !String.IsNullOrWhiteSpace(v));
    
    query.SelectMany (q => q, (a, b) => b).Dump();

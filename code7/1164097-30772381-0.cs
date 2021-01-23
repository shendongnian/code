    Dictionary<string, List<string>> dictTestdata = new Dictionary<string, List<string>>
                {
                    { "k1", new List<string> { "1", "Programmers" }},
                    { "k2", new List<string> { "3", "Testers" }},
                    { "k3", new List<string> { "", "Designers" }}, 
                };
    
                var result1 = dictTestdata.Where(kvp => string.IsNullOrWhiteSpace(kvp.Value[0]))
                      .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    
                dictTestdata = new Dictionary<string, List<string>>
                {
                    { "k1", new List<string> { "", "Programmers" }},
                    { "k2", new List<string> { "", "Testers" }},
                    { "k3", new List<string> { "", "Designers" }}, 
                };
    
                var result2 = dictTestdata.Where(kvp => string.IsNullOrWhiteSpace(kvp.Value[0]))
                      .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

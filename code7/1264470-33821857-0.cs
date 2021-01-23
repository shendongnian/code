    IDictionary<string, int> wordsAndCount = new Dictionary<string, int>
    {
    	{"Batman", 987987987},
    	{"MeaningOfLife",42},
    	{"Fun",69},
    	{"Relaxing",420},
    	{"This", 2}
    };
    
    var result = wordsAndCount.OrderBy(d => d.Value).Select(d => new 
    {
       Word = d.Key,
       Count = d.Value
    });

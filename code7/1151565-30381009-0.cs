    private Dictionary<string, int> Splitter(string[] file, bool distinct, bool pairs)
    {
    	var query = file
    		.SelectMany(i => File.ReadLines(i)
    		.SelectMany(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
    		.AsParallel()
    		.Select(word => word.ToLower())
    		.Where(word => !word.All(char.IsDigit)));
    		
    	if (pairs)
    		query = query.Concat(query.Pairwise((first, second) => string.Format("{0} {1}", first, second)));
    
    	if(distinct)
    		query = query.Distinct();
    
    	return query
    		.GroupBy(word => word)
    		.ToDictionary(g => g.Key, g => g.Count());
    }

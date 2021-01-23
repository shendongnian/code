    private IEnumerable<string> GetNonConsecutiveEmails(List<string> list)
    {
    	var groups = list.Distinct().GroupBy(l => l.Split('@')[1]).Select (l => l.ToArray()).ToArray();
    	
    	for(int i = 0; i < list.Count; i++)
    		foreach(var g in groups.Where(g => g.Length > i))
    			yield return g.Skip(i).Take(1).First();
    }

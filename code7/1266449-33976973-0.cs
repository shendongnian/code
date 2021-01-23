    //tokenize input (enumerable of string)
    var words = Regex.Matches(input, @"\w+").Cast<Match>().Select(m => m.Value);
    
    //get word groups (enumerable of string[])
    var groups = GetWordGroups(words, 3);
    
    //do what you want with your groups; suppose you want to count them
    var counts = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
    foreach (var group in groups.Select(g => string.Join(" ", g)))
    {
    	int count;
    	counts.TryGetValue(group, out count);
    	counts[group] = ++count;
    }
    
    
    IEnumerable<string[]> GetWordGroups(IEnumerable<string> words, int size)
    {
    	if (size <= 0) throw new ArgumentOutOfRangeException();
    	if (size == 1)
    	{
    		foreach (var word in words)
    		{
    			yield return new string[] { word };
    		}
    		
    		yield break;
    	}
    
    	var prev = new string[0];
    
    	foreach (var next in GetWordGroups(words, size - 1))
    	{
    		yield return next;
    
    		//stream of groups includes all groups up to size - 1, but we only combine groups of size - 1
    		if (next.Length == size - 1)
    		{
    			if (prev.Length == size - 1)
    			{
    				var group = new string[size];
    				Array.Copy(prev, 0, group, 0, prev.Length);
    				group[group.Length - 1] = next[next.Length - 1];
    				yield return group;
    			}
    
    			prev = next;
    		}
    	}
    }

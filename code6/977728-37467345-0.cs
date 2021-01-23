    public IEnumerable<string> fsm(string s)
    {
    	int i, a = 0, l = s.Length;
    	var q = true;
    	for (i = 0; i < l; i++)
    	{
    		switch (s[i])
    		{
    			case ',':
    				if (q)
    				{
    					yield return s.Substring(a, i - a).Trim();
    					a = i + 1;
    				}
    				break;
    			// pick your flavor
    			case '"':
    			//case '\'':
    				q = !q;
    				break;
    		}
    	}
    	yield return s.Substring(a).Trim();
    }
    
    // === usage ===
    var row = fsm(csvLine).ToList();
    foreach(var column in fsm(csvLine)) { ... }

    private static IEnumerable<int> Sum(string inp)
    {
    	int i = 0, s = 0, z = 1;
    	foreach (var v in inp.Split('#').Select(int.Parse))
    	{
    		s += v;
    		if (++i == z)
    		{
    			z++;
    			yield return s;
    			s = i = 0;
    		}
    	}
    	
    }

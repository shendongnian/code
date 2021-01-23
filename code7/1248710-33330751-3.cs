    private static IEnumerable<int[]> Permute(int[] list)
    {
    	if (list.Length > 1)
    	{    
    		int n = list[0];
    		foreach (int[] subPermute in Permute(list.Skip(1).ToArray()))
    		{    
    			for (int index = 0; index <= subPermute.Length; index++)
    			{
    				int[] pre = subPermute.Take(index).ToArray();
    				int[] post = subPermute.Skip(index).ToArray();
    
    				if (post.Contains(n))
    					continue;
    
    				yield return pre.Concat(new[] { n }).Concat(post).ToArray();
    			}    
    		}
    	}
    	else
    	{
    		yield return list;
    	}
    }

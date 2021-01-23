    public class TreeLevel1
    {
	    public IEnumerable<TreeLevel2> TreeLevel2Enumerator()
	    {
		    for (int i = 0; i < treeLevel2List.Count; i++)
    		{
    			yield return treeLevel2List[i];
    		}
    		yield break;
    	}
    	public IEnumerable<TreeLevel3> TreeLevel3Enumerator()
    	{
    		for (int i = 0; i < treeLevel2List.Count; i++)
    		{
    			TreeLevel2 lvl2=treeLevel2List[i];
    			for(int j =0; j<lvl2.treeLevel3List.Count; j++)
    			{ 
    				yield return lvl2.treeLevel3List[j];
    			}
    		}
    		yield break;
    	}
    }

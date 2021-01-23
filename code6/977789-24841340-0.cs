    class GroupAuthorityComparer : IComparer<GroupAuthority>
    {
    	public int Compare(GroupAuthority a, GroupAuthority b)
    	{
    		if (a != null && b != null && (a.Id == 0 || b.Id == 0))
    		{
    			if (a.Id == b.Id)
    			{
    				// Mandatory as some sort algorithms require Compare(a, b) and Compare(b, a) to be consitent
    				return 0; 
    			}
    			return a.Id == 0 ? -1 : 1;
    		}
    		
    		// The default comparer correctly handle null values
    		return Comparer<string>.Default.Compare(a.Name, b.Name);
    	}
    }
    
    
    void Main()
    {
    	var items = new []
    	{
    		new GroupAuthority("Z", 15),
    		new GroupAuthority("A", 5),
    		new GroupAuthority("Public", 0)
    	};
    	
    	items.OrderBy(_ => _, new GroupAuthorityComparer()).Dump();
    }

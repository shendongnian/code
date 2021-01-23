    class GroupAuthority : IComparable<GroupAuthority>
    {
    	public string Name;
    	public int Id; 
    	
    	public GroupAuthority(string name, int id)
    	{
    		Name = name;
    		Id = id;
    	}
    	
    	public int CompareTo(GroupAuthority b)
    	{
    		if (b != null && (Id == 0 || b.Id == 0))
    		{
    			if (Id == b.Id)
    			{
    				// Mandatory as some sort algorithms require Compare(a, b) and Compare(b, a) to be consitent
    				return 0; 
    			}
    			return Id == 0 ? -1 : 1;
    		}
    		
    		return Comparer<string>.Default.Compare(Name, b.Name);
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
    	
    	items.OrderBy(_ => _).Dump();
    }

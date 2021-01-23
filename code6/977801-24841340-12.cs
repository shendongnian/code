    class Group : IComparable<Group>
    {
        ...
    	
    	public int CompareTo(Group b)
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

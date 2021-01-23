    class GroupAuthority : IComparable<GroupAuthority>
    {
        ...
    	
    	public int CompareTo(GroupAuthority b)
    	{
    		return Comparer<Group>.Default.Compare(Group, b.Group);
    	}
    }

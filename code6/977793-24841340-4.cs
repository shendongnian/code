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
    
    		if (a == null || b == null)
    		{
    			if (ReferenceEquals(a, b))
    			{
    				return 0;
    			}
    			return a == null ? 1 : -1;
    		}
            return Comparer<string>.Default.Compare(a.Name, b.Name);
        }
    }

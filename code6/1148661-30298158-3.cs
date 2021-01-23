    sealed class MyComparer : IEqualityComparer<UserGroupMap>
    {
    	public bool Equals(UserGroupMap x, UserGroupMap y)
    	{
    		if (x == null)
    			return y == null;
    		else if (y == null)
    			return false;
    		else
    			return x.UserId == y.UserId
    				 && x.GroupId == y.GroupId
    				 && x.FormGroupFlag == y.FormGroupFlag
    				 && x.GroupDescription == y.GroupDescription
    				 && x.GroupName == y.GroupName;
    	}
    
    	public int GetHashCode(UserGroupMap obj)
    	{
    		unchecked
    		{
    			int hash = 17;
    
    			hash = hash * 23 + (obj.UserId ?? "").GetHashCode();
    			hash = hash * 23 + (obj.GroupId ?? "").GetHashCode();
    			hash = hash * 23 + (obj.FormGroupFlag ?? "").GetHashCode();
    			hash = hash * 23 + (obj.GroupDescription ?? "").GetHashCode();
    			hash = hash * 23 + (obj.GroupName ?? "").GetHashCode();
    
    			return hash;
    		}
    	}
    }

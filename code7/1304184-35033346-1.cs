    public class InfraestructuraComparer: IEqualityComparer<INFRAESTRUCTURA>
    {
    	public bool Equals(INFRAESTRUCTURA firstObj, INFRAESTRUCTURA secondObj)
    	{
    		if (firstObj == null && secondObj == null)
    			return true;
    
    		if (firstObj == null || secondObj == null)
    			return false;
    
    		// Your equality logic goes to here
    		return firstObj.ID == secondObj.ID;
    	}
    
    	public int GetHashCode(INFRAESTRUCTURA obj)
    	{
            if (obj == null) return 0;
    		unchecked
    		{
    			var hash = 17;
    
    			hash = hash * 23 + obj.Id.GetHashCode();
    
    			return hash;    
    		}
    	}
    }

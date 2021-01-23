    public class InfraestructuraComparer: IEqualityComparer<INFRAESTRUCTURA>
    {
        /// <summary>
        /// Whether the two INFRAESTRUCTURA are equal.
        /// </summary>
    	public bool Equals(INFRAESTRUCTURA firstObj, INFRAESTRUCTURA secondObj)
    	{
    		if (firstObj == null && secondObj == null)
    			return true;
    
    		if (firstObj == null || secondObj == null)
    			return false;
    
    		// Your equality logic goes to here
    		return firstObj.ID == secondObj.ID;
    	}
    
        /// <summary>
        /// Return the hash code for this instance.
        /// </summary>
    	public int GetHashCode(INFRAESTRUCTURA obj)
    	{
            // Don't compute hash code on null object.
            if (obj == null) return 0;
    		unchecked
    		{
    			var hash = 17;
    
    			hash = hash * 23 + obj.Id.GetHashCode();
    
    			return hash;    
    		}
    	}
    }

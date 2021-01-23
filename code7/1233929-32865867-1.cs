    public class DictComparerById : IEqualityComparer<Dictionary<string, string>>
    {
        public bool Equals(Dictionary<string, string> x, Dictionary<string, string> y)
        {
    		// Two dictionary are equal if the have the same "id"
    		string idX;
    	    if(!x.TryGetValue("id", out idX))
    			x.TryGetValue("roleid", out idX);
    		
    		string idY;
    	    if(!y.TryGetValue("id", out idY))
    			y.TryGetValue("roleid", out idY);
    		
            return (idX == idY);
        }
    
        public int GetHashCode(Dictionary<string, string> x)
        {
    		string id;
    	    if(!x.TryGetValue("id", out id))
    			x.TryGetValue("roleid", out id);
            return id.GetHashCode();
        }
    }

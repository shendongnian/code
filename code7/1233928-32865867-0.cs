    public class DictComparerById : IEqualityComparer<Dictionary<string, string>>
    {
        public bool Equals(Dictionary<string, string> x, Dictionary<string, string> y)
        {
    		// Two dictionary are equal if the have the same "id"
    		string idX;
    	    x.TryGetValue("id", out idX);
    		string idY;
    	    y.TryGetValue("id", out idY);
            return (idX == idY);
        }
    
        public int GetHashCode(Dictionary<string, string> x)
        {
    		string id;
    	    x.TryGetValue("id", out id);
            return id.GetHashCode();
        }
    }

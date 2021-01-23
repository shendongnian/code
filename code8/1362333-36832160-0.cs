    public class PrimaryKey : IEquable<PrimaryKey>
    {       
        // other properties
        bool Equals(PrimaryKey other)
        {
            return this.Date == other.Date && this.ID1 == other.ID1 && this.ID2 == other.ID2;
        }
	    override int GetHashCode()
	    {
		    return this.Date.GetHashCode() ^ this.ID2.GetHashCode() ^ this.ID2.GetHashCode();
	    }
    }

    public class CustomEqualityComparer : IEqualityComparer<Participant>
    {
    	public bool Equals(Participant x, Participant y)
    	{
    	    return x.UserId == y.UserId && x.Name == y.Name;
    	}
    
    	public int GetHashCode(Participant obj)
    	{
    	    return new Tuple<int, string>(obj.UserId, obj.Name).GetHashCode();
    	}
    }

    public class SentEqualityComparer : IEqualityComparer<Sent>
    {
    	public int GetHashCode(Sent sent)
    	{
    		return sent.Address.GetHashCode() ^ sent.Data.GetHashCode();
    	}
    	
    	public bool Equals(Sent left, Sent right)
    	{
    		return (left.Address == right.Address) && (left.Data == right.Data);
    	}
    }

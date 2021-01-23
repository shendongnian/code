    public class CustomTuple : Tuple<IReadOnlyList<string>, DateTime?>
    {
        public CustomTuple(IEnumerable<string> strings, DateTime? time)
          : base(strings.OrderBy(x => x).ToList().AsReadOnly(), time)
        {
        }
    	
    	public override bool Equals(object o1)
    	{
    		// as above
    	}
    	
    	public override int GetHashCode()
    	{
            // as above
    	}
    	
    }

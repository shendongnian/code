    public class SpecialList<T> : List<T>
    {
	    public new int Add(T Item)
    	{
    		if (Contains(Item))
            {
    			return IndexOf(Item);
            }
    		else
            {
    			base.Add(Item);
    			return Count - 1;
            }
    	}
    }

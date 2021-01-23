    public abstract class MyAbstractClass : IEnumerable<int>
    {
    	private List<int> tempList = new List<int>();
    	public IEnumerator GetEnumerator()
    	{
    		return tempList.GetEnumerator();
    	}
    	IEnumerator<int> IEnumerable<int>.GetEnumerator()
    	{
    		return tempList.GetEnumerator();
    	}
    }
    MyAbstractClass myClass = null;
    MyAbstractClass instance = myClass.EmptyIfNull();

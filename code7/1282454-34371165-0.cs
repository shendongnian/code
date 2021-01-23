    public interface IChildItem
    { }
    
    public interface IItem<T> where T: class
    {
    	List<T> Children { get; }
    }
    
    public class ChildItem1 : IChildItem
    { }
    
    public class ChildItem2 : IChildItem
    { }
    
    public class Item1 : IItem<ChildItem1>
    {
    	public List<ChildItem1> Children
    	{
    		get { return null; }
    	}
    }
    
    public class Item2 : IItem<ChildItem2>
    {
    	public List<ChildItem2> Children
    	{
    		get { return null; }
    	}
    }

    void Main()
    {
    	//your original class:
    	List<Things> originalList = new List<Things> { new Things(5), new Things(3), new Things(5) };
    	//i'm doing this in LINQPad; if you're using VS you may need to foreach the object
    	Console.WriteLine(originalList);
    	//put your duplicates back in a list and log them as you did.
    	var duplicateItems = originalList.GroupBy(x => x.ID).Where(x => x.Count() > 1).ToList();//.Select(x => x.GetHashCode());
    	Console.WriteLine(duplicateItems);
    	//create a custom comparer to compare your list; if you care about more than ID then you can extend this
    	var tec = new ThingsEqualityComparer();
    	var listThings = new HashSet<Things>(tec);
    	listThings.UnionWith(originalList);
    	Console.WriteLine(listThings);
    }
    
    // Define other methods and classes here
    public class Things 
    {
    	public int ID {get;set;}
    	
    	public Things(int id)
    	{
    		ID = id;
    	}
    }
    
    public class ThingsEqualityComparer : IEqualityComparer<Things>
    {
    	public bool Equals(Things thing1, Things thing2)
    	{
    		if (thing1.ID == thing2.ID)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    	
    	public int GetHashCode(Things thing)
    	{
    		int hCode = thing.ID;
    		return hCode.GetHashCode();
    	}
    }

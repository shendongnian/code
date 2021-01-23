    class Program
    {
    	static void Main(string[] args)
    	{
    		string[] fruit1 = { "Apple", "Banana", "Orange", "Pear", "Strawberry", "Grape", "Kiwi" };
    		string[] fruit2 = { "Peach", "Nectarine", "Banana", "Cherry" };
    		string[] fruit3 = Names.UniqueSortedJoin(fruit1, fruit2);
    	}
    }
    
    class Names
    {
    	public static string[] UniqueSortedJoin(string[] names1, string[] names2)
    	{
    		return names1.Concat(names2)
    			.Distinct()
    			.OrderBy(x => x)
    			.ToArray();
    	}
    }

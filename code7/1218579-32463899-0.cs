    void Main()
    {
    	var lstItemCol = new List<Item>();
    
    	lstItemCol.Add(new Item("EE", "12345"));
    	lstItemCol.Add(new Item("WW", "5881"));
    	lstItemCol.Add(new Item("LLL", "215458"));
    	lstItemCol.Add(new Item("WW", "789"));
    	lstItemCol.Add(new Item("EE", "582"));
    
    	lstItemCol.OrderBy(ic => ic).Dump();
    	lstItemCol.OrderBy(ic => ic, new ItemComparer()).Dump();
    }
    
    // Define other methods and classes here
    
    class Item : IComparable<Item>, IComparable
    {
    	public string ItemType { get; set; }
    	public string Code { get; set; }
    
    	// other members elided
    
    	public Item(string _IT, string _Cd)
    	{
    		ItemType = _IT;
    		Code = _Cd;
    	}
    
    	public int CompareTo(Item other)
    	{
    		if (other == null) return 1;
    		var result = ItemType.Length.CompareTo(other.ItemType.Length);
    		if (result == 0) result = ItemType.CompareTo(other.ItemType);
    		if (result == 0) result = Code.Length.CompareTo(other.Code.Length);
    		if (result == 0) result = Code.CompareTo(other.Code);
    		return result;
    	}
    	int IComparable.CompareTo(object other)
    	{
    		return CompareTo(other as Item);
    	}
    }
    
    sealed class ItemComparer : FComparer<Item>
    {
    	private static readonly Func<Item, Item, int> _comparer = (v1, v2) =>
    	{
    		var result = v1.ItemType.Length.CompareTo(v2.ItemType.Length);
    		if (result == 0) result = v1.ItemType.CompareTo(v2.ItemType);
    		if (result == 0) result = v1.Code.Length.CompareTo(v2.Code.Length);
    		if (result == 0) result = v1.Code.CompareTo(v2.Code);
    		return result;
    	};
    	
    	public ItemComparer()
    		:base(_comparer)
    	{ }
    }
    
    abstract class FComparer<T> : IComparer<T>
    {
    	private readonly Func<T, T, int> _comparer;
    
    	protected FComparer(Func<T, T, int> comparer)
    	{ _comparer = comparer; }
    
    	public int Compare(T v1, T v2)
    	{
    		return _comparer(v1, v2);
    	}
    }

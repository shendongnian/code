    public class OverridePropertiesWithSameField
    {
    	public void Test()
    	{
    		ChildItem ci = new ChildItem();
    		ChildItemData cid = new ChildItemData();
    		cid.ItemDataProp = "ItemDataProperty"; // Inherited
    		cid.ChildItemDataProp = "ChildItemDataProp"; // Specific
    		ci.ItemData = cid;
    
    		// You know you need ChildItemData type here.
    		var childItemData = ci.ItemData as ChildItemData;
    		string itemDataProp = childItemData.ItemDataProp;
    		string childItemDataProp = childItemData.ChildItemDataProp;
    	}
    }
    
    public class Item
    {
    	protected ItemData data;
    	public virtual ItemData ItemData { get; set; }
    }
    
    public class ChildItem : Item
    {
    	public override ItemData ItemData
    	{
    		get { return base.data; }
    		set { base.data = value; }
    	}
    }
    
    public class ItemData
    {
    	public string ItemDataProp { get; set; }
    }
    
    public class ChildItemData : ItemData
    {
    	public string ChildItemDataProp { get; set; }
    }

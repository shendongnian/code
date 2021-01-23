    private List<Dictionary<string, string>> _DictionaryList;
    
    protected void Page_Init(object sender, EventArgs e)
    {
    	var dictionary = new Dictionary<string, string>
    	{
    		{ "Max", "Berlin" }, 
    		{ "John", "New York" }, 
    		{ "Mike", "London" }, 
    		{ "Tedd", "Miami" }
    	};
    
    	var dictionary2 = new Dictionary<string, string>
    	{
    		{ "cat", "Milk" },
    		{ "dog", "Meat" }, 
    		{ "llama", "Water" }
    	};
    
    	_DictionaryList = new List<Dictionary<string, string>>
    	{
    		dictionary, 
    		dictionary2
    	};
    
    	repeaterInfo.DataSource = _DictionaryList;
    	repeaterInfo.DataBind();
    }
    
     protected void ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		var innerRepeater = e.Item.FindControl("rptrInner") as System.Web.UI.WebControls.Repeater;
    		var footerRepeater = e.Item.FindControl("rptrFooter") as System.Web.UI.WebControls.Repeater;
    
    		innerRepeater.DataSource = _DictionaryList[e.Item.ItemIndex];
    		innerRepeater.DataBind();
    
    		footerRepeater.DataSource = Enumerable.Range(1, _DictionaryList.Count).Select(i => new { ItemIndex = i, ShouldHighlight = e.Item.ItemIndex + 1 == i });
    		footerRepeater.DataBind();
    	}
    }

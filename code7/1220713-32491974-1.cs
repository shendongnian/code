    // Assuming your service will return [element] types
    class element
    {
    	public string LabelText { get; set; }
    	public List<string> Items { get; set; }
    }
    
    public partial class WebForm4 : System.Web.UI.Page
    {
    	private static Random RNG = new Random(DateTime.Now.Millisecond);
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		PopulateData();
    	}
    	
    	private void PopulateData()
    	{
    		// Pseudo service data
    		var serviceData = Enumerable.Range(1, 10).Select(i => new element
    		{
    			LabelText = "Some Text " + i,
    			Items = Enumerable.Range(1, RNG.Next(3, 12)).Select(j => " Item " + j).ToList()
    		});
    
    		myListview.DataSource = serviceData;
    		myListview.DataBind();
    	}
    
    	protected void listview_ItemDataBound(object sender, ListViewItemEventArgs e)
    	{
    		
    		if(e.Item.ItemType == ListViewItemType.DataItem)
    		{
    			var dataItem = e.Item.DataItem as element;
    			var cbl = e.Item.FindControl("cblItems") as CheckBoxList;
    			cbl.DataSource = dataItem.Items;
    			cbl.DataBind();
    		}
    	}
    }

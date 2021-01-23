    protected void Page_Load(object sender, EventArgs e)
    {
    	if(!Page.IsPostBack)
    	{
    		this.dpdCategory.Items.Clear();
    		this.dpdCategory.Items.Add(new ListItem("hello", "0"));
    		this.dpdCategory.Items.Add(new ListItem("hello", "1"));
    	}
    }

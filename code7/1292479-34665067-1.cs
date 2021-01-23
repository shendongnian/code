    protected void Page_Load(object sender, EventArgs e)
    {
    	AutoMapperConfiguration.Initialize();
    	dtvProcurements.DataBind();
    }
    
    protected void dtvProcurements_DataBound(object sender, EventArgs e)
    {
    	GridView1.DataBind();
    } 

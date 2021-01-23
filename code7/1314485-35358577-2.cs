    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
         {
             gvBind(); //Bind gridview
         }
    }
    
    public void gvBind()
    {   
    	 var myTable=DerializeDataTable()
    	 gvstatus.DataSource = myTable;
    	 gvstatus.DataBind();
    }

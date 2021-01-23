    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		var dt = GetInitialData();
    
    		gv1.DataSource = dt;
    		gv1.DataBind();
    
    		Session["dt"] = dt;
    	}
    }
    
    protected void AddUsername(object sender, EventArgs e)
    {
    	var dt = Session["dt"] as DataTable;
    
    	var row = dt.NewRow();
    	row["Username"] = txt1.Text;
    	dt.Rows.Add(row);
    
    	gv1.DataSource = dt;
    	gv1.DataBind();
        Session["dt"] = dt;
    }
    
    private DataTable GetInitialData()
    {
    	var dt = new DataTable();
    	dt.Columns.Add("Username");
    
    	for (int i = 1; i <= 5; i++)
    	{
    		var row = dt.NewRow();
    		row["Username"] = string.Format("user name {0}", i);
    		dt.Rows.Add(row);
    	}
    
    	return dt;
    }

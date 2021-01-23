    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		// Check permissions here
    		if (allowed) 
    		{
    			// For custom/user control
    			UserAnnouncements.GetAnnouncements();
    			// For grid view
    			GridView1.DataSource = GetGridviewData(); // GetGridviewData would return DataSet or anything valid.
    			GridView1.DataBind();
    		}
    		else
    		{
    			// Hide the controls
    		}
    	}
    }

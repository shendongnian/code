	string conString;
	SqlConnection con;
	
    protected void Page_Load(object sender, EventArgs e)
    {
		conString = Session["ConnectionString"].ToString();
		// Check here for conString == null, if necessary.
		con = new SqlConnection(conString);
    }
	

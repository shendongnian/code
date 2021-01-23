    protected void Page_Load(object sender, EventArgs e)
    	{
    	   DataTable dt= (DataTable)Session["MyGridData"];
           if (dt.Rows.Count > 0)
            { 
                 GridView1.DataSource = dt;
                 GridView1.DataBind();
           }
    	}

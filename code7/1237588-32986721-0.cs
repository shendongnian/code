    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["myquery"]!= null)
        {
            try
            {
                DS_GRIDVIEW1.SelectCommand = Session["myquery"].ToString();
                GRIDVIEW1.DataBind();
            }
            catch (Exception)
            {
                Session["myquery"] = null;    
            }
        
        }
    }

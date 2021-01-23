    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    
    protected void gv_Deleting(object sender, GridViewDeleteEventArgs e)
    {
        ...
        deleteNumber(SID, phone_number, 9);
        BindData();
    }
    
    private void BindData()
    {
        ...
        gv.DataSource = ds;
        gv.DataBind();
    }

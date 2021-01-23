    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            BindDetails();
            TextBox txtQuantity = (TextBox)gvDetailList.Rows[0].Cells[4].FindControl("txtQuantity");
            txtQuantity.Focus();
        }
    }
    private void BindDetails()
    {        
        string strSQL = "SELECT  * FROM TABLE";
        SqlDetailList.SelectCommand = strSQL;
        gvDetailList.DataSource = SqlDetailList;
        gvDetailList.DataBind();
    }
    protected void gvDetailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {        
        gvDetailList.PageIndex = e.NewPageIndex;
        BindDetails();
    }
    protected void gvDetailList_PageIndexChanged(object sender, EventArgs e)
    {
        TextBox txtQuantity = (TextBox)gvDetailList.Rows[0].Cells[4].FindControl("txtQuantity");
        txtQuantity.Focus();
    }

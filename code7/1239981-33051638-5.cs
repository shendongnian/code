    protected void Page_Load(object source, System.EventArgs e)
    {
    
    
        dynamic data = new[] {
    new { ID = 1, Name ="Name_1", SalesPrice = 10.00}
    };
        DataList1.DataSource = data;
        DataList1.DataBind();
    }
    protected void Page_PreRender(object source, System.EventArgs e)
    {
        if (Request.QueryString["SalesPrice"] != null && !string.IsNullOrEmpty(Request.QueryString["SalesPrice"]))
        {
            string salePrice = Request.QueryString["SalesPrice"];
            ((Label)DataList1.Controls[0].FindControl("PriceLabel")).Text = salePrice;
        }
    }

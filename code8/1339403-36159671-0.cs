    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
        if (ViewState["List1_Value"] != null)
        {
            ddl1.SelectedValue = ViewState["List1_Value"].ToString();
        }
    }

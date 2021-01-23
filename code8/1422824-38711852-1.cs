    public void Page_Load(object sender, EventArgs e)
    {
        string Div = String.Empty;
        if (Request.QueryString["Value"] != null)
        {
            Div = Request.QueryString["Value"].ToString();
        }
        if (!IsPostBack)
        {
            this.BindGrid(Div);
        }
    }

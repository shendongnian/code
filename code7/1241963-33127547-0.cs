    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["sorting"] = "Ascending";
        }
            caseLoads();
    }

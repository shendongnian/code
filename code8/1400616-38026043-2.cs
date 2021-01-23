    public string QueryString1;
    public string QueryString2;
    protected void Page_Load(object sender, EventArgs e)
    {
    
        QueryString1 = Request.QueryString["QueryString1"].ToString();
        QueryString2 = Request.QueryString["QueryString2"].ToString();
        LinkButton2.PostBackUrl = "WebForm4.aspx?id=" + QueryString1;
    }

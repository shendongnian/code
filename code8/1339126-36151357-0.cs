    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["PERNR"].ToString();
        Label2.Text = Session["ZZFNAME"].ToString();
        if (!IsPostBack)
        {
            TextBox1.Text = Session["MOBILE"].ToString();
        }
    }

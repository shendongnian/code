    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!IsPostBack)
        {
               Label1.Text = Session["PERNR"].ToString();
               Label2.Text = Session["ZZFNAME"].ToString();
               TextBox1.Text = Session["MOBILE"].ToString();
        }
    }

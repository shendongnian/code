    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request.QueryString["B1"] != null)
        {
            CheckBox1.Checked = true;
        }
    }

    public string FirstName { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        FirstName = "XYZ";
        if (!IsPostBack)
              Label1.DataBind();
    }

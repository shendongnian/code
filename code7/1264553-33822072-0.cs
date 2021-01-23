    public string Name { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Name = "XYZ";
        if (!IsPostBack)
              Label1.DataBind();
    }

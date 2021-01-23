    void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            checkBox.DataSource = SomethingFromDatabase();
            checkBox.DataTextField = "Name";
            checkBox.DataValueField = "ID";
            checkBox.DataBind();
        }
    }

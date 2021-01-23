    protected void Page_Load( object sender, EventArgs e) 
    {
       if(!Page.IsPostBack)
       {
            Repeater.DataSource = images;
            Repeater.DataBind();
       }
    }

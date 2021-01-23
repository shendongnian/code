    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listview.DataSource = your_data_source;
            listview.DataBind();
         }
    }

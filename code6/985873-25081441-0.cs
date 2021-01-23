    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        FilterCombo.DataSoure = myDataSource;
        FilterCombo.DataBind();
      }
    }

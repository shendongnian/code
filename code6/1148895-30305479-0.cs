    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        pagenumberLabel.Text = GetPagingCaptionString();
      }
    }

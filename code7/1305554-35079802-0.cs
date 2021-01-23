    // code-behind of ucControl1
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
        ucControl2.Visible = false;
    }
    
    protected void btn_Click(object sender, EventArgs e)
    {
        ucControl2.Visible = true;
    }

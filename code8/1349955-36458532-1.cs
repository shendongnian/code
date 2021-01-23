    protected void Page_Load(object sender, EventArgs e)
    {
      if (IsPostBack) {
        if(Session["name"] == null)
          Session["name"] = txtName.Text.Trim();
      else
       txtName.Text = Session["name"].ToString() 
      }
    }

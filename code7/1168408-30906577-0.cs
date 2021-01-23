    protected void Page_Load(object sender, EventArgs e)
        {
        if (Session["user"] != null)
        {
            txtName.Text = Session["user"].ToString();
        }

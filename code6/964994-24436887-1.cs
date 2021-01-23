    protected void Page_Load(object sender, EventArgs e)
    {
        lblSession.Text = Session.SessionID;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
    }

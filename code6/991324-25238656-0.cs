    protected void Page_Load(object sender, EventArgs e)
    {
        if (!isPostBack)
        {
        status.Text = "First time on page";
        }
    }
    protected void action(object sender, EventArgs e)
    {
        status.Text = "Hello world!";
    }

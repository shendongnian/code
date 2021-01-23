    protected string link = "http://www.test.com";
    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    testLabel.Text = string.Format("You also have to click on is <a href=\"{0}\"> link </a>",link);
                }
            }

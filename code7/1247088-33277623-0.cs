    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["Clicks"] == null)
                {
                    ViewState["Clicks"] = 0;
                }
                Label1.Text = ViewState["Clicks"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int ClicksCount = (int)ViewState["Clicks"] + 1;
            Label1.Text = ClicksCount.ToString();
            ViewState["Clicks"] = ClicksCount;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int ClicksCount = (int)ViewState["Clicks"] - 1;
            Label1.Text = ClicksCount.ToString();
            ViewState["Clicks"] = ClicksCount;
        }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            SetTimeout();
    }
    
    public void SetTimeout() {
        int secondsAhead = 30;
        Session["timeout"] = DateTime.Now.AddSeconds(secondsAhead).ToString();
    }

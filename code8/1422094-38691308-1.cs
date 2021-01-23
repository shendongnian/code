    protected void Page_Load(object sender, EventArgs e)
    {
        bool isHungry = Boolean.Parse(Request.QueryString["isHungry"]);
        string menuItem = Request.QueryString["menuItem"].ToString();
        //Write your SQL query here and make sure you check the parameters to prevent SQL injection attacks
    }

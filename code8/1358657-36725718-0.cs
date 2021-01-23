    protected void Page_Load(object sender, EventArgs e)
    {
        // If this is the initial page load (not a post back), 
        // or if there's not already an end time in Session, 
        // then set the end time
        if (!Page.IsPostBack || Session["end_t"] == null)
        {
            DateTime start_time = DateTime.Now;
            DateTime end_time = start_time.AddMinutes(3);
            Session["end_t"] = end_time;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.UserAgent.Contains("Googlebot"))
                {
                    //it's one of the google robots
                }
                else if (...)
                {
                    ...
                }
            }

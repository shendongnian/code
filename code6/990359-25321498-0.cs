    protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var btn in Master.FindControl("ContentPlaceHolder1").Controls.OfType<LinkButton>())
            {
                btn.Click += log;
            }
        }
    
        void log(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            //somecode
        }

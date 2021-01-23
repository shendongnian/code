        public void Page_Load(object sender, EventArgs e)
        {
            if(Request.HttpMethod == "POST" && Request.QueryString["method"] == "ViewMyDevices")
            {
                ViewMyDevices();
            }
        }

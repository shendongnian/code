    public WebsiteUserManager WebUserManager
        {
            get
            {
                return _webUserManager ?? Request.GetOwinContext().GetUserManager<WebsiteUserManager>();
            }
            private set
            {
                _webUserManager = value;
            }
        }

    public Controller Admin
    {
        public ActionResult Index()
        {
            if (!IsUserInRole("Administrator"))
            {
                // redirect "not allowed"
            }
            return View();
        }
    }

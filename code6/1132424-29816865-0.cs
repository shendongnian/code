        [Route("user", Name = "first")]
        public ActionResult Index(string user)
        {
            return View();
        }
        [Route("company", Name = "second")]
        public ActionResult Index2(string company)
        {
            return View();
        }

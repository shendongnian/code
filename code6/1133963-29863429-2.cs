        public ActionResult Index()
        {
            string[] roles = new string[] { "Admin", "Supervisor", "Interviewer" };
            Session["data"] = roles;
            return RedirectToAction("Test", "Student");
        }
        public ActionResult Test()
        {
            string[] roles = (string[])Session["data"];
            return View("Index");
        }

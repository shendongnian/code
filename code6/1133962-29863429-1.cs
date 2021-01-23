        public ActionResult Index()
        {
            string[] roles = new string[] { "Admin", "Supervisor", "Interviewer" };
            TempData["data"] = roles;
            return RedirectToAction("Test", "Student");
        }
        public ActionResult Test()
        {
            string[] roles = (string[])TempData["data"];
            return View("Index");
        }

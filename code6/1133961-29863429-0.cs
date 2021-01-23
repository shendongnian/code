        public ActionResult Index()
        {
            string[] roles = new string[] { "Admin", "Supervisor", "Interviewer" };
            var routeParameters = new RouteValueDictionary();
            for (int i = 0; i < roles.Length; i++)
            {
                routeParameters["roles[" + i + "]"] = roles[i];
            }
            return RedirectToAction("Test", "Student", routeParameters);
        }
        public ActionResult Test(string[] roles)
        {
            return View("Index");
        }

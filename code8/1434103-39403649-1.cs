        Models.EmpModel mod = new Models.EmpModel();
        public ActionResult Index()
        {
            List<EMPTABLE> result = mod.GetEmployees();
            return View(result);
        }
        public ActionResult Details(int id)
        {
            EMPTABLE result = mod.GetEmployee(id);
            return View(result);
        }
    }

         [HttpGet]
        public ActionResult Index()
        {
            AdminModel model = new AdminModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(AdminModel model,FormCollection c)
        {
            if (ModelState.IsValid)
            {
               return RedirectToAction("Index", new { Controller = "Sample1" });
            }
        
                return View(model);
           
        }

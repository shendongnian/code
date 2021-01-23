        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactModels());
        }
        [HttpPost, Admin]
        public ActionResult Index(ContactModels model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            //Call a service that saves to database
            
            return RedirectToAction("ListOfContacts");
        }

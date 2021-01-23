        public ActionResult Index()
        {
            ViewBag.Country = Enum.GetValues(typeof(Countries)).Cast<Countries>().ToList().Select(r => new SelectListItem { Text = r.ToString(), Value = ((int)r).ToString() });
            return View();
        }
        [HttpPost]
        public ActionResult Index(Countries country)
        {
            var saveit = country;
            // whatever you wish to do with the result;
            return Content(saveit.ToString());
        }

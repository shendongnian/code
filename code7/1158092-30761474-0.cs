        public ActionResult Index()
        {
            var model = new HomeViewModel { Id = 123 };
            return View(model);
        }
        public void RecordClick(int id)
        {
            int incomingId = id;
        }

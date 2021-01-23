        public ActionResult Index()
        {
          OnlineModel model = new OnlineModel();
          var result = model.GetAdminData();
          return View(result);
        }

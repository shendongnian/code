    public ActionResult Index() {
       var model = new IndexViewModel {
          TopNav = "services",
          // set other properties here
       }
       return View(model);
    }

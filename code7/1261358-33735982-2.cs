    public ActionResult Index() {
        var viewModel = new HomeViewModel {
    	     Text = "My Text"
    	};
    	return View(viewModel);
    }

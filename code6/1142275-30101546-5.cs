	public ActionResult Index()
	{
	    var viewModel = new ViewModel();
		
		// take data from Session
		pa_ipv4 pa_ipv4 = Session["pa_ipv4Session"] as (pa_ipv4);
		// some verification	
		// add the list from Session to model
		viewModel.ExistingIps = pa_ipv4.ExistingIps;
		return View(viewModel);
	}

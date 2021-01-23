	public async Task<IActionResult> Index()
	{
		// Methods RestMethod = new Methods();
		var data = await Methods.Get("http://url/products", "domain\userid", "Password");
		return View();
	}
	

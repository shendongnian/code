    [Authorize(Roles = "Producer")]
    [Authorize(Roles = "Editor")]
	public ActionResult Details(int id) {
		// .. action body
	}

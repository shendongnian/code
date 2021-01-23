    [HttpPost]
	public ActionResult NewProduct(Product newProduct) {
		if (newProduct == null) { throw new NullReferenceException("model is null D:"); }
		// Do other things
		return View();
	}

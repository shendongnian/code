	[HttpPost]
	public ActionResult Update(CustomerModel model)
	{
		// Update customer here...
		var currentNode = this.GetCurrentSiteMapNode();
		if (currentNode != null)
		{
			var parentNode = currentNode.ParentNode;
			if (parentNode != null)
			{
				return Redirect(parentNode.Url);
			}
		}
		return View(model);
	}

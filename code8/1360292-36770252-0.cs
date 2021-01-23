    [HttpPost]
	public ActionResult MyCtroller(myViewModel model)
	{
		var result = new ActualInstanceOrContainerToBeReturned;
		return Json(result, JsonRequestBehavior.AllowGet);
	}

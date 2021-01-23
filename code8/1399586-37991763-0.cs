	[HttpGet]
	public ActionResult CallService(int id)
	{
		string color = id.ToString();
		return Json(new {
			color = color
			myfamily = "razzaqi"
		}, JsonRequestBehavior.AllowGet);
	}
	

	public ActionResult BaseView()
	{
		ViewBag.Data = SalesRepository.SalesCount();
		return View();
	}
	[ChildActionOnly]
	public ActionResult ChildView1(List<DataRow> sales)
	{
	}

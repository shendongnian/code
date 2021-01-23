	public JsonResult FetchMonths(int selectedYear)
	{
		IEnumerable<int> months = db.yourTable().Where(x => x.Year == selectedYear).Select(x => x.Month);
		return Json(months, JsonRequestBehavior.AllowGet);
	}

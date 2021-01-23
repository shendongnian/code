	public JsonResult Data()
	{
		return Json(new DimensionGetter.GetDimensions(), JsonRequestBehavior.AllowGet);
	}
	public void ReadData()
	{
		var model = new DimensionGetter.GetDimensions();
	}

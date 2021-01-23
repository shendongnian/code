	[HttpPost]
	public JsonResult Edit(int id)
	{
		if (id == 0)
		{
			return Json(new {url = ""});
		}
		else
		{
			return Json(new { url = Url.Action("EditPage", new { id = id }) });
		}
	}

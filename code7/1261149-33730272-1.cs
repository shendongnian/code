	 [HttpPost]
	 public JsonResult DeleteSection(int id)
		{
			try
			{
				//get section by id
				var section = _service.GetSection(id);
				DeleteSection(section);
				return Json("success",JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				//log e
				return Json("failed",JsonRequestBehavior.AllowGet);
			}
		}

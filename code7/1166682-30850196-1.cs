	public JsonResult IsUserNameAvailable(string userName, int? UserId)
	{
		var users = new BusinessLayer.BdsAdmin.Users();
		if (UserId.HasValue)
		{
			users.GetBySqlStatement("SELECT * FROM [User] WHERE [UserName]='{0}' AND [UserId]<>{1}", userName, UserId.Value);
		} else {
			users.GetBySqlStatement("SELECT * FROM [User] WHERE [UserName]='{0}'", userName);
		}
		if (users.Count == 0)
		{
			return Json(true, JsonRequestBehavior.AllowGet);
		}
		string msg = string.Format("{0} is already taken and is not available.", userName);
		return Json(msg, JsonRequestBehavior.AllowGet);
	}
	

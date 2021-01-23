	public JsonResult IsUserNameAvailable(string userName, int UserId)
	{
		var users = new BusinessLayer.BdsAdmin.Users();
		users.GetBySqlStatement("SELECT * FROM [User] WHERE [UserName]='{0}' AND [UserId]<>{1}", userName, (int)UserId);	// add some exception safe conversion of types here
		if (users.Count == 0)
		{
			return Json(true, JsonRequestBehavior.AllowGet);
		}
		string msg = string.Format("{0} is already taken and is not available.", userName);
		return Json(msg, JsonRequestBehavior.AllowGet);
	}
	

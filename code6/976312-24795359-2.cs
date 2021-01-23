    [HttpGet]
    public ActionResult GetUserData(string userID)
    {
        string userName = ...; // get user name from database here
        string email = ""; // get email from database here
        return Json(new { ID = userID, UserName = userName, Email = email }, JsonRequestBehavior.AllowGet);
    }

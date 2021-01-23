    public JsonResult doesUserNameExist(string username)
    {
        var user = Membership.GetUserByName(username.Trim());
        return user == null ? 
    		Json(true, JsonRequestBehavior.AllowGet) : 
    		Json(string.Format("{0} is not available.", username),
    			JsonRequestBehavior.AllowGet);
    }

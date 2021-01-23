    public JsonResult IsUsernameValid(string UserName, int UserID = 0)
    {
        var isValid = true; 
        
        if (UserName != null)
        {
            isValid = !db.Users.Where(x => x.UserName == UserName && x.UserID != UserID).Any();                         
        }
        return Json(isValid, JsonRequestBehavior.AllowGet);
    }

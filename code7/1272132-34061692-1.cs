    var pic = GetFileData(user.Id);
    public JsonResult GetUsers()
    {
        var ret = (from user in db.Users
                   orderby user.UserName
                   select new
                   {
                       UserName = user.UserName,
                       Pic = pic,
                   }).AsEnumerable();
        return Json(ret, JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetUsers()
    {
        var ret = (from user in db.Users.ToList()
                   orderby user.UserName
                   select new
                   {
                       UserName = user.UserName,
                       Pic = GetFileData(user.Id),
                   }).AsEnumerable();
        return Json(ret, JsonRequestBehavior.AllowGet);
    }

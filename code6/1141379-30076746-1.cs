    [HttpPost]
    public JsonResult SetUser(string userid)
    {
        return Json(new { UserID = Convert.ToInt64(userid) });
    }

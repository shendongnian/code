    public JsonResult Divisibility(int Amount)
    {
        var value = User.Identity.GetUserId().Where(x => x.Equals("qqqqq"));
        
        return Json(value == null);
    }

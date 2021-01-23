    [HttpPost]
    public JsonResult Divisibility(ModelName model)
    {
        //user your variable name
        model.Value = User.Identity.GetUserId().Where(x => x.Equals("qqqqq"));
        return Json(value == null);
    }

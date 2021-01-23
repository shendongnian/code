    public ActionResult Example(string code)
    {
        if(string.IsNullorEmpty(code))
        {
            UrlHelper urlHelper = new UrlHelper(HttpContext.Request.RequestContext);
            string actionUrl = urlHelper.Action("Index", "Home");
            return Json(new { success = false, message = "Code not provided", redirectTo = actionUrl});
        }
        else
        {
            return Json(new { success = true, message= "Next step"});
        }
    }

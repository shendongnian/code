    public ActionResult SetCulture(string culture)
    {
            HttpContext.Session["culture"] = culture;
            //all your logic
            return Redirect(Request.UrlReferrer.AbsoluteUri);
    }   

    public ActionResult Index()
    {
        if (Request.Cookies["selectBoxValue"] != null)
        {
            var cookie = new HttpCookie("selectBoxValue")
            {
                Expires = DateTime.Now.AddYears(1),
                Value = "CookieValueGoesHere"
            };
            Response.Cookies.Add(cookie);
        }
        return View("Index");
    }

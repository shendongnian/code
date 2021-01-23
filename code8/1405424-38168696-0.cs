    public ActionResult DoSomething()
    { 
         HttpCookie cookie = new HttpCookie("ShowAlert");
         cookie.Value = "1";
         this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
         return RedirectToAction("Dashboard", "Home", new { message = 1 });
    }
    
    public ActionResult Dashboard(int? message)
    {
        if (!this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("ShowAlert"))
        {
            return View("Index");
        }
   
            HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["ShowAlert"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            if (message == 1)
                return Content("<script language='javascript' type='text/javascript'>alert('Merchant on Hold');</script>");
            else
                return Content("<script language='javascript' type='text/javascript'>alert('indefiend Message');</script>");
        }
    }

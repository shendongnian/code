    public ActionResult ReturnPartialView ()
    {
       if (Request != null && Request.IsAjaxRequest())
       {
          ViewBag.ReturnUrl = Url.Action("Action", "Controller");
          .
          .
          .
       }
       return null;
    }

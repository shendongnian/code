    public ActionResult Check()
    {
     ViewBag.SessionData = Session["names"] as List<DetailsList>;
    
     Return View();
    }

    public ActionResult PreviousAction()
    {    
        ViewBag.Notification = db.Notification.ToList();    
        return View();
    }

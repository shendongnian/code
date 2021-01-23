    public ActionResult AnotherAction(int id)
    {
        //Do something with the id ...
        return View()
    }
    public RedirectToRouteResult DoAndRedirect()
    {            
        //Do something and go to the desired view:
        return RedirectToAction("AnotherAction", new { id = x.ID });
    }

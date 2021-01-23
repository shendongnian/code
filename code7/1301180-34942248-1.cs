    public ActionResult yourPage()
    {
        return View();
    }
    [HttpPost]
    public ActionResult yourPage(yourFormModal yfm)
    {
        var firstName = yfm.FirstName;
        var lastName = yfm.LastName;
        var email = yfm.Email;
    
        //do whatever you want...
    
        return View();
    }

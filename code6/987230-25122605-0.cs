    public ActionResult Agence(AgenceQuery model)
    {
        var result = Test.Areas.Admin.Models.WebUser.GetUser(model.Num_RA);
        if (result == null)
        {
            ViewBag.Error = "CustomError, Cette agence n'éxiste pas";
        }
    
        return View();
    }
    

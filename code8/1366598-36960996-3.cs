    [System.Web.Services.WebMethod]
    public ActionResult getAll(string id,string name)
    {
        return RedirectToAction("NameOfAction"); //Here is going Name of Action       wich returns View AllUser.cshtml
     
    }

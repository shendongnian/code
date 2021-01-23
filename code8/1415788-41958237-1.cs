    public ActionResult PartialView()
    {
        // DO YOUR STUFF. 
        return PartialView("PartialView", model);
    }
    [HttpPost, ValidateInput(false)]
    public ActionResult POSTPartialView(string param1)
    {
        // DO YOUR STUFF AFTER SUBMIT.
        return new EmptyResult();
    } 

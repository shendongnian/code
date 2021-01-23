    public ActionResult MyMethod()
    {
        .....
        //Check the GUID ??
        if (id == null)
        {
            return RedirectToAction("BadRequestError");
        }
        
        .....
    }

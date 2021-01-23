    [HttpPost] 
    public ActionResult SubmitComment(FormCollection collection)
    {
       string comment = collection["comment"];
    }

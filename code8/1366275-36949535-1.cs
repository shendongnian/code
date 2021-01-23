    public ActionResult Index(ModelVM modelVM, FormCollection collection)
    {
        if(ModelState.IsValid) {
            if(modelVM.RD == null) {
                ModelState.AddModelError("RD", "RD is invalid.");
            }
        }
        if (!ModelState.IsValid)
            return Json(new
            {
                Result = "ERROR",
                Message = "Missing fields."
            });
        return Json("OK");
    }

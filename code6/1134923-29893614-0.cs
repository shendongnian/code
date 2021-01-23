    [HttpPost]
    public ActionResult someAction(MyModel obj)
    {
       if (!ModelState.IsValid)
       {
          ModelState.AddModelError("", "Error occured");
          return Json("Error occured", JsonRequestBehavior.AllowGet);
       }
       ...
    }

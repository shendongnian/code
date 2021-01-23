    public ActionResult RegisterBand(ProfileViewModel model)
    {
        if (ModelState.IsValid == false)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
        return View("Index");
    }

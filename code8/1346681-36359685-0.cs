    public ActionResult RegisterBand(BandProfileViewModel model)
    {
        if (ModelState.IsValid == false)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
        return View("Index");
    }

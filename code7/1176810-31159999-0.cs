    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SURV_Main_Create(SURV_Main_Model surv_main_model)
    {
      if (ModelState.IsValid)
      {
        ....
      }
      ViewBag.GroupList = new SelectList(db.SURV_Group_Model, "Group_ID", "GroupName"); // add this
      return View(surv_main_model);
    }

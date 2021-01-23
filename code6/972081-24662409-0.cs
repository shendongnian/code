    public ActionResult Edit(int id)
    {
        if (ShouldAllowEdit(id))
        {
          return this.View("Edit", ...edit stuff...)              
        }
        ModelState.AddModelError("id", "Not allowed to edit this item");
        return RedirectToAction(Edit(id));
    }

    [HttpPost]
    public async Task<ActionResult> Renewal(RenewalViewModel vm)
    {
        if (!ModelSTate.IsValid)
        {
            // Populate the SelectList's
            model.Webpage = ....
            model.AddTime = ....
            return View(vm);
        }
        // Get the data model
        WebPages model = db.WebPagesList.Where(x => x.WebPagesId == vm.SelectedWebPage).FirstOrDefault();
        if (model != null)
        {
            // Not really sure if you mean AddYears or AddDays?
            model.DomainExp = model.DomainExp.AddYears(vm.SelectedDurationDays);
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
        // Redirect
        return RedirectToAction(....);
    }

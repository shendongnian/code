    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Partner partner)
    {
        if (ModelState.IsValid)
        {
             var localizedDisplayName = partner.PartnersGroup.GetDisplayValue();
             // Save to DB
        }        
    }

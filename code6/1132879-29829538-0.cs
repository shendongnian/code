    public ActionResult Edit(Guid id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var license = licenseRepo.GetLicense(id);
        licenseRepo.Dispose();
        if (license == null)
        {
            return HttpNotFound();
        }
        return View(license);
    }

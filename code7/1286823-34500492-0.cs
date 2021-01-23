    [HttpPost]
    [Authorize(Roles = "Administrator,Editors")]
    public ActionResult EditPat(inspListaNoParte model)
    {
        try
        {
            var oldModel = bff.inspListaNoPartes.Find(model.IdNumPart);
            bff.Entry(oldModel).State = EntityState.Modified;
            oldModel.UMC = model.UMC;
            bff.SaveChanges();
            TempData["AlertMessage"] = "Success";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Error";
            throw;
        }
        return View();
    }

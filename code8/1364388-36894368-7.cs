    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "EncaissementID,libelle,DateEncaissement,Montant,ProjetID,Description")] Encaissement encaissement) {
      // Perform validation
      if (!encaissement.DateEncaissement.HasValue)
      {
          this.ModelState.AddModelError("DateEncaissement", "The DateEncaissement must be set");
      }
      encaissement.Montant = Convert.ToDecimal(encaissement.Montant);
      ViewBag.montant = encaissement.Montant;
      if (ModelState.IsValid) {
        db.Encaissements.Add(encaissement);
        db.SaveChanges();
        return RedirectToAction("Index", "Encaissement");
      };
      ViewBag.ProjetID = new SelectList(db.Projets, "ProjetId", "nomP");
      return View(encaissement);
    }

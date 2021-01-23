    [HttpPost]
    public ActionResult BikeEdit(BikeEditVm model)
    {
      var bikeEntity = db.Bikes.FirstOrDefault(s=>s.Id==model.id);
      if(bikeEntity!=null)
      {
        bikeEntity .ModelName = model.ModelName;
        bikeEntity .Color = model.Color;   
        db.Entry(bikeEntity).State=EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Bikes","Home");
      }
      return View("NotFound");
    }
